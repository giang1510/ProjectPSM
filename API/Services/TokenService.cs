﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

// TODO make this more secure
// maybe: asymmetric key instead of symmetric
// maybe: using something else instead of JWT for session mechanism
public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey? _key;
    private const string ConfigTokenKey = "TokenKey"; // TODO add to a constants class

    public TokenService(IConfiguration config)
    {
        var tokenKey = config[ConfigTokenKey];
        if (tokenKey != null) _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
    }

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
