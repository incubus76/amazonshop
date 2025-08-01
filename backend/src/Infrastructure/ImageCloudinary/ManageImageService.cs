using System.Drawing;
using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Models.ImageManagement;
using Microsoft.Extensions.Options;

namespace Ecommerce.Infrastructure.ImageCloudinary;

public class ManageImageService: IManageImageService
{
    public CloudinarySettings _cloudinarySettings { get; }

    public ManageImageService(IOptions<CloudinarySettings> cloudinarySettings)
    {
        _cloudinarySettings = cloudinarySettings.Value;
    }

    public async Task<ImageResponse> UploadImage(ImageData imageData)
    {
        var account = new Account
        {
            Cloud = _cloudinarySettings.CloudName,
            ApiKey = _cloudinarySettings.ApiKey,
            ApiSecret = _cloudinarySettings.ApiSecret
        };

        var cloudinary = new Cloudinary(account);

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(imageData.Nombre, imageData.ImageStream)
        };

        var uploadResult = await cloudinary.UploadAsync(uploadParams);

        if (uploadResult.StatusCode == HttpStatusCode.OK)
        {
            return new ImageResponse
            {
                Url = uploadResult.Url.ToString(),
                PublicId = uploadResult.PublicId
            };
        }
        
        throw new Exception($"Error uploading image: {uploadResult.Error?.Message}");
    }
}