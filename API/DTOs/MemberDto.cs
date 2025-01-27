namespace API.DTOs;

/// <summary>
/// Data of other users from server to client
/// </summary>
public class MemberDto
{
    public required string Username { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? KnownAs { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastActive { get; set; }
    public string? Gender { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}
