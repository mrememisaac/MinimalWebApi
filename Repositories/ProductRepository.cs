namespace ProductsApi.Repositories;

using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Entities;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext dbContext;

    public ProductRepository(ApplicationDbContext context)
    {
        dbContext = context;
    }

    public async Task<Product> Add(Product product, CancellationToken cancellationToken)
    {
        dbContext.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<List<Product>> List(int page = 0, int numberOfRecords = 100, CancellationToken cancellationToken)
    {
        page = page < 0 ? 0 : page;
        numberOfRecords = Math.Min(numberOfRecords, 100);
        return await dbContext.Products.OrderBy(x => x.Id).Skip(page * numberOfRecords).Take(numberOfRecords).ToListAsync();
    }

    public async Task<Product?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
        return product;
    }

    public async Task<Product> Update(Product product, CancellationToken cancellationToken)
    {
        dbContext.Entry(product).State = EntityState.Modified;
        await dbContext.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var product = await GetById(id, cancellationToken);
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}