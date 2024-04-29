namespace API.DTOs;

/// <summary>
/// Represents review data to send back to client
/// </summary>
public class ReviewDto
{
    public short Rating { get; set; }
    public required string Headline { get; set; }
    public string? WrittenReview { get; set; }
    public DateTime Created { get; set; }

    // Foreign keys
    public int ProductId { get; set; }
    public int UserId { get; set; }
}
