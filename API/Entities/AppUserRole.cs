using Microsoft.AspNetCore.Identity;

namespace API.Entities;

/// <summary>
/// Represents AppUser-AppRole-Pair in the database
/// </summary>
public class AppUserRole : IdentityUserRole<int>
{
    public AppUser User { get; set; } = null!;
    public AppRole Role { get; set; } = null!;
}
