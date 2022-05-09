namespace MinimalWebApi.Repositories;

using MinimalWebApi.Data;
using MinimalWebApi.Entities;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext dbContext;

    public ProductRepository(ApplicationDbContext context)
    {
        dbContext = context;
    }

    public async Task<Product> Add(Product product)
    {
        dbContext.Add(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> List(int page = 1, int numberOfRecords = 50)
    {
        page = page < 0 ? 0 : page;
        numberOfRecords = Math.Min(numberOfRecords, 100);
        return dbContext.Products.Skip(page).Take(numberOfRecords).AsEnumerable();
    }
}