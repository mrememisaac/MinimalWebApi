namespace MinimalWebApi.Data;

using Microsoft.EntityFrameworkCore;
using MinimalWebApi.Entities;

public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Collection of Products in our database
    /// </summary>
    /// <typeparam name="Product"></typeparam>
    /// <returns></returns>
    public DbSet<Product> Products => Set<Product>();

    /// <summary>
    /// Collection of Product Pictures in our database
    /// </summary>
    /// <typeparam name="Picture"></typeparam>
    /// <returns></returns>
    public DbSet<Picture> Pictures => Set<Picture>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        optionsBuilder.UseSqlite($"Data Source={Path.Join(path, "Products.db")}");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Telling EF Core exactly how I want my tables created to avoid surprises
        builder.Entity<Product>(p =>
        {
            p.ToTable("Products").HasKey(k => k.Id);
            p.Property(p => p.Description);
            p.Property(p => p.Name);
            p.Property(p => p.Price);
            p.Property(p => p.CreatedBy);
            p.Property(p => p.DateCreated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
        });
        builder.Entity<Picture>(p =>
        {
            p.ToTable("Pictures").HasKey(p => p.Id);
            p.Property(p => p.Base64String);
            p.HasOne(p => p.Product);
            p.Property(p => p.CreatedBy);
            p.Property(p => p.DateCreated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
        });

        //Load seed data
        Seeder.Seed(builder);
    }
}