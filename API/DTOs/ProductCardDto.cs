using API.Entities;

namespace API.DTOs;

/// <summary>
/// Product data to show in a list from server to client
/// </summary>
public class ProductCardDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Category { get; set; }
    public bool IsActive { get; set; }
    public string? Manufacturer { get; set; }

    public List<PhotoDto> Photos { get; set; } = new();
    public List<ReviewDto> Reviews { get; set; } = new();
}
