using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

/// <summary>
/// Represents new review to be added from client
/// </summary>
public class ReviewEntryDto
{
    [Range(1, 5)]
    public short Rating { get; set; }

    [StringLength(128, MinimumLength = 4)]
    public required string Headline { get; set; }
    public string? WrittenReview { get; set; }
    public int ProductId { get; set; }
}
