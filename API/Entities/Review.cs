namespace API.Entities;

/// <summary>
/// Data row of a review in the database
/// </summary>
public class Review
{
    public int Id { get; set; }
    public short Rating { get; set; }
    public string? Headline { get; set; }
    public string? WrittenReview { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;

    // Foreign keys
    public int ProductId { get; set; }
    public required Product Product { get; set; }
    public int UserId { get; set; }
    public required AppUser User { get; set; }
}
