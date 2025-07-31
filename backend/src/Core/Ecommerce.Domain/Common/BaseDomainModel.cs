namespace Ecommerce.Domain.Common;

public abstract class BaseDomainModel
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; } = DateTime.UtcNow;
    public string? LastModifiedBy { get; set; }
}