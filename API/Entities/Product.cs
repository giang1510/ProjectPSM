namespace API.Entities;

/// <summary>
/// Represents product data row in database
/// </summary>
public class Product
{
    // TODO is int really enough?
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public required string Category { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
    public string? Manufacturer { get; set; }

    public List<ProductPhoto> Photos { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}
