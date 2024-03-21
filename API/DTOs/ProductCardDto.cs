using API.Entities;

namespace API.DTOs;

public class ProductCardDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Category { get; set; }
    public bool IsActive { get; set; }
    public string? Manufacturer { get; set; }

    public List<PhotoDto> Photos { get; set; } = new();
}
