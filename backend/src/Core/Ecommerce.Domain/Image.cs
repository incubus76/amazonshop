using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain;

public class Image : Common.BaseDomainModel
{
    [Column(TypeName = "NVARCHAR(400)")]
    public string? Url { get; set; }
    public int ProductId { get; set; }
    public string? PublicCode { get; set; }
    public virtual Product? Product { get; set; }

    // Additional properties and methods can be added here as needed
}