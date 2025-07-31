using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class OrderItem : BaseDomainModel
{
    public Product? Producto { get; set; }
    public int ProductId { get; set; }
    public int Cantidad { get; set; }

    public decimal Precio { get; set; }
    public Order? Order { get; set; }
    public int OrderId { get; set; }
    public int ProductItemId { get; set; }
    public string? ProductNombre { get; set; }
    public string? ImageUrl { get; set; }
    

    // Additional properties and methods can be added here as needed

}