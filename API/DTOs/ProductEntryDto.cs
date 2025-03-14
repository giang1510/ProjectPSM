using System;

namespace API.DTOs;

public class ProductEntryDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Category { get; set; }
    public string? Manufacturer { get; set; }
}
