namespace API.Entities;

/// <summary>
/// Represents photo data row in database
/// </summary>
public abstract class Photo
{
    public int Id { get; set; }
    public required string Url { get; set; }
    public string? PublicId { get; set; }
}
