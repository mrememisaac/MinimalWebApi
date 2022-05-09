namespace MinimalWebApi.Repositories;

using MinimalWebApi.Entities;

public interface IProductRepository
{
    Task<IEnumerable<Product>> List(int page = 1, int numberOfRecords = 50);

    Task<Product> Add(Product product);
}
