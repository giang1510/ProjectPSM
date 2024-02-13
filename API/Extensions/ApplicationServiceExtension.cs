using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

/// <summary>
/// Use to encapsulate addtions of services in Program.cs
/// </summary>
public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();

        return services;
    }
}
