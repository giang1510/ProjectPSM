using API.Constants;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

/// <summary>
/// Use to encapsulate addtions of services in Program.cs
/// </summary>
public static class ApplicationServiceExtension
{
    /// <summary>
    /// Extension method to add services to builder.services in Program.cs
    /// </summary>
    /// <param name="services">builder.services</param>
    /// <param name="config">currently used for database config</param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString(ConfigurationKeys.DBDefaultConnection));
        });
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IWebScrapeService, WebScrapeService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddCors();

        return services;
    }

    // TODO Move this method to a more suited place
    /// <summary>
    /// Extension method to create seed data in Program.cs
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static async Task MigrateSeedData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<DataContext>();
            await context.Database.MigrateAsync();
            await Seed.SeedUsers(context);
            await Seed.SeedProducts(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetService<ILogger<Program>>();
            logger?.LogError(ex, "An error occurred during migration");
        }
    }
}
