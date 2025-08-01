using Ecommerce.Application.Models.Authorization;
using Ecommerce.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ecommerce.Infrastructure.Persistence;

public class EcommerceDbContextData
{
    public static async Task LoadDataAsync(
        EcommerceDbContext context,
        UserManager<Usuario> usuarioManager,
        RoleManager<IdentityRole> roleManager,
        ILoggerFactory loggerFactory
    )
    {
        try
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Role.ADMIN));
                await roleManager.CreateAsync(new IdentityRole(Role.USER));
            }

            if (!usuarioManager.Users.Any())
            {
                var usuarioAdmin = new Usuario
                {
                    UserName = "Ismael",
                    Apellido = "Moreno",
                    Email = "impipo@hotmail.com",
                    NormalizedUserName = "impipo",
                    Telefono = "123456789",
                    AvatarUrl = "https://avatars.githubusercontent.com/u/12345678?v=4",
                };
                await usuarioManager.CreateAsync(usuarioAdmin, "12345");
                //await usuarioManager.AddToRoleAsync(usuarioAdmin, Role.ADMIN);

                var usuario = new Usuario
                {
                    UserName = "Juan",
                    Apellido = "perez",
                    Email = "juan.perez@hotmail.com",
                    NormalizedUserName = "jperez",
                    Telefono = "123456789",
                    AvatarUrl = "https://avatars.githubusercontent.com/u/87654321?v=4",
                };
                await usuarioManager.CreateAsync(usuario, "12345");
                //await usuarioManager.AddToRoleAsync(usuario, Role.USER);
            }

            if (!context.Categories.Any())
            {
                var categoryData = File.ReadAllText("../Infrastructure/Data/category.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                await context.Categories!.AddRangeAsync(categories!);
                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var productData = File.ReadAllText("../Infrastructure/Data/product.json");
                var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                await context.Products!.AddRangeAsync(products!);
                await context.SaveChangesAsync();
            }

            if (!context.Images.Any())
            {
                var imageData = File.ReadAllText("../Infrastructure/Data/image.json");
                var images = JsonConvert.DeserializeObject<List<Image>>(imageData);
                await context.Images!.AddRangeAsync(images!);
                await context.SaveChangesAsync();
            }

            if (!context.Reviews.Any())
            {
                var reviewData = File.ReadAllText("../Infrastructure/Data/review.json");
                var reviews = JsonConvert.DeserializeObject<List<Review>>(reviewData);
                await context.Reviews!.AddRangeAsync(reviews!);
                await context.SaveChangesAsync();
            }

            if (!context.Countries.Any())
            {
                var countryData = File.ReadAllText("../Infrastructure/Data/countries.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);
                await context.Countries!.AddRangeAsync(countries!);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<EcommerceDbContextData>();
            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
}