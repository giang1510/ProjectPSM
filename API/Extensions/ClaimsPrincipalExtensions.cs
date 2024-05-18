using System.Security.Claims;

namespace API.Extensions;

/// <summary>
/// Encapsulate extension methods to ClaimsPrincipal
/// - identity handler
/// </summary>
public static class ClaimsPrincipalExtensions
{
    /// <summary>
    /// Get username from API call
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static string? GetUsername(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
