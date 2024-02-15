using System.ComponentModel.DataAnnotations;

namespace API.Entities;

/// <summary>
/// Represents app user data row in the database
/// </summary>
public class AppUser
{
    // TODO remove unnecessary fields
    public int Id { get; set; }

    public required string Username { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? KnownAs { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public string? Gender { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    // TODO add photos field
}
