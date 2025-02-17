using Microsoft.AspNetCore.Identity;

namespace API.Entities;

/// <summary>
/// Represents user role in the database
/// e.g. admin, moderator, normal, ...
/// </summary>
public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; } = [];
}
