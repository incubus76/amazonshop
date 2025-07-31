using System.Runtime.Serialization;

namespace Ecommerce.Domain;

public enum ProductStatus
{
    [EnumMember(Value = "Producto Activo")]
    Active = 1,
    [EnumMember(Value = "Producto Inactivo")]
    Inactive = 2,
}