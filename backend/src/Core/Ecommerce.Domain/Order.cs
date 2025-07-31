using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class Order : BaseDomainModel
{
    public Order(){

    }

    public Order(
        string compradorNombre,
        string compradorUserName,
        OrderAddress orderAddress,
        decimal subtotal,
        decimal total,
        decimal impuesto,
        decimal precioEnvio
    )
    {
        CompradorNombre = compradorNombre;
        CompradorUserName = compradorUserName;
        OrderAddress = orderAddress;
        Subtotal = subtotal;
        Total = total;
        Impuesto = impuesto;
        PrecioEnvio = precioEnvio;
    }

    public string? CompradorNombre { get; set; }
    public string? CompradorUserName { get; set; }
    public OrderAddress? OrderAddress { get; set; }
    public IReadOnlyList<OrderItem>? OrderItems { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Subtotal { get; set; }
    public OrderStatus Status { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Impuesto { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal PrecioEnvio { get; set; }
    public string? PaymentIntentId { get; set; }
    public string? ClientSecret { get; set; }
    public string? StripeApiKey { get; set; }


}