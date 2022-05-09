namespace MinimalWebApi.Data;

using Microsoft.EntityFrameworkCore;
using MinimalWebApi.Entities;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public DbSet<Picture> Pictures => Set<Picture>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        optionsBuilder.UseSqlite($"Data Source={Path.Join(path, "Products.db")}");
    }
}