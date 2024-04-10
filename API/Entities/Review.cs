namespace API.Entities;

public class Review
{
    public int Id { get; set; }
    public short Rating { get; set; }
    public required string Headline { get; set; }
    public string? WrittenReview { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;

    // Foreign keys
    public int ProductId { get; set; }
    public required Product Product { get; set; }
    public int UserId { get; set; }
    public required AppUser User { get; set; }
}
