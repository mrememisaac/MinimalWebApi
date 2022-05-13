namespace MinimalWebApi.Repositories;

using MinimalWebApi.Entities;

public interface IProductRepository
{
    Task<IEnumerable<Product>> List(int page = 0, int numberOfRecords = 100);

    Task<Product> Add(Product product);
}
