namespace API.DTOs;

public class ProductDetailDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public required string Category { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
    public string? Manufacturer { get; set; }

    public List<PhotoDto> Photos { get; set; } = new();
    public List<ReviewDto> Reviews { get; set; } = new();
}
