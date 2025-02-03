using System.Text;
using API.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API;

/// <summary>
/// Extension methods to configure idetity/token services
/// </summary>
public static class IdentityServiceExtension
{
    /// <summary>
    /// Add authentication via token to builder.services in Program.cs
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        // TODO make it more secure
        var tokenKey = config[ConfigurationKeys.TokenKey];
        if (tokenKey == null) throw new ArgumentNullException(nameof(tokenKey));
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return services;
    }
}
