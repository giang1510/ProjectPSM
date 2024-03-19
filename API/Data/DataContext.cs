using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

/// <summary>
/// Represents session with database to access folloing data:
/// AppUser
/// </summary>
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Product> Products { get; set; }
}
