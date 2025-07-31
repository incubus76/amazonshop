using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class Category : BaseDomainModel
{
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Name { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    // Additional properties and methods can be added here as needed
}