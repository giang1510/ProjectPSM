using System.Text;
using API.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API;

public static class IdentityServiceExtension
{
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
