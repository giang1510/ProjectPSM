using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API;

public static class Seed
{
    public static async Task SeedUsers(DataContext context)
    {
        if (await context.Users.AnyAsync()) return;

        var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);
        if (users == null) return;
        foreach (var user in users)
        {
            using var hmac = new HMACSHA512();
            user.Username = user.Username.ToLower();
            // TODO Make seeding more secure
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")); // only for testing purposes
            user.PasswordSalt = hmac.Key;

            context.Users.Add(user);
        }

        await context.SaveChangesAsync();
    }

    public static async Task SeedProducts(DataContext context)
    {
        if (await context.Products.AnyAsync()) return;

        var productData = await File.ReadAllTextAsync("Data/ProductSeedData.json");
        var productPhotoData = await File.ReadAllTextAsync("Data/ProductPhotoSeedData.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        var products = JsonSerializer.Deserialize<List<Product>>(productData, options);
        var photos = JsonSerializer.Deserialize<List<PhotoDto>>(productPhotoData, options);
        if (products == null || photos == null) return;
        for (int i = 0; i < products.Count; i++)
        {
            products[i].Photos.Add(new ProductPhoto
            {
                Url = photos[i].Url,
                Product = products[i]
            });
            context.Products.Add(products[i]);
        }

        await context.SaveChangesAsync();
    }
}
