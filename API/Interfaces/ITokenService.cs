using API.Entities;

namespace API;

/// <summary>
/// Interface for TokenService
/// </summary>
public interface ITokenService
{
    string CreateToken(AppUser user);
}
