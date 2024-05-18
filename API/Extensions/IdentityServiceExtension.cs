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
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    // TODO throw exception when token key is empty
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config[ConfigurationKeys.TokenKey])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return services;
    }
}
