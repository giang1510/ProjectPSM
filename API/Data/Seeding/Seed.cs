using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API;

/// <summary>
/// Populate database with test data
/// </summary>
public static class Seed
{
    /// <summary>
    /// Create test users
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static async Task SeedUsers(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager
    )
    {
        if (await userManager.Users.AnyAsync())
            return;

        var userData = await File.ReadAllTextAsync("Data/Seeding/UserSeedData.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, };

        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);
        if (users == null)
            return;

        var roles = new List<AppRole>
        {
            new AppRole { Name = "Member" },
            new AppRole { Name = "Admin" },
            new AppRole { Name = "Moderator" },
        };
        foreach (var role in roles)
        {
            await roleManager.CreateAsync(role);
        }

        foreach (var user in users)
        {
            // TODO make this more secure
            // TODO add transaction for potential rollback
            await userManager.CreateAsync(user, "Pa$$w0rd");
            await userManager.AddToRoleAsync(user, "Member");
        }

        await AddAdminAccount(userManager);
    }

    private static async Task AddAdminAccount(UserManager<AppUser> userManager)
    {
        var admin = new AppUser
        {
            UserName = "admin",
            KnownAs = "Admin",
            Gender = "",
            DateOfBirth = new(1900, 1, 1),
            EmailAddress = "admin@psm.com"
        };

        // TODO add transaction for potential rollback
        await userManager.CreateAsync(admin, "Pa$$w0rd");
        await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
    }

    /// <summary>
    /// Create test products
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static async Task SeedProducts(DataContext context)
    {
        if (await context.Products.AnyAsync())
            return;

        var productData = await File.ReadAllTextAsync("Data/Seeding/ProductSeedData.json");
        var productPhotoData = await File.ReadAllTextAsync(
            "Data/Seeding/ProductPhotoSeedData.json"
        );

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, };

        var products = JsonSerializer.Deserialize<List<Product>>(productData, options);
        var photos = JsonSerializer.Deserialize<List<PhotoDto>>(productPhotoData, options);
        if (products == null || photos == null)
            return;
        for (int i = 0; i < products.Count; i++)
        {
            products[i].Photos.Add(new ProductPhoto { Url = photos[i].Url, Product = products[i] });
            context.Products.Add(products[i]);
        }

        await context.SaveChangesAsync();
    }
}
