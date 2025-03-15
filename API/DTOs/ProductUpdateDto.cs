using System;

namespace API.DTOs;

public class ProductUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? Category { get; set; }
    public bool? IsActive { get; set; }
    public string? Manufacturer { get; set; }
}
