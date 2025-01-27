using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Constants;
using API.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

// TODO make this more secure
// maybe: asymmetric key instead of symmetric
// maybe: using something else instead of JWT for session mechanism
/// <summary>
/// Service for handling token (user authentication)
/// </summary>
public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey? _key;

    public TokenService(IConfiguration config)
    {
        var tokenKey = config[ConfigurationKeys.TokenKey];
        if (tokenKey != null) _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
    }

    /// <summary>
    /// Create a token for member access
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string CreateToken(AppUser user)
    {
        var claims = new List<Claim>{
            new Claim(JwtRegisteredClaimNames.NameId, user.Username)
        };

        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);

    }
}
