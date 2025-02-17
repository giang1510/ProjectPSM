using Microsoft.AspNetCore.Identity;

namespace API.Entities;

/// <summary>
/// Represents app user data row in the database
/// </summary>
public class AppUser : IdentityUser<int>
{
    // TODO remove unnecessary fields

    public required DateOnly DateOfBirth { get; set; }
    public required string EmailAddress { get; set; }
    public string? KnownAs { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public string? Gender { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    public List<Review> Reviews { get; set; } = [];
    public ICollection<AppUserRole> UserRoles { get; set; } = [];

    // TODO add photos field
}
