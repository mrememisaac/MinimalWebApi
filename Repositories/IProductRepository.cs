namespace ProductsApi.Repositories;

using ProductsApi.Entities;

public interface IProductRepository
{
    Task<List<Product>> List(int page = 0, int numberOfRecords = 100, CancellationToken cancellationToken = default);

    Task<Product> Add(Product product, CancellationToken cancellationToken);

    Task<Product> GetById(Guid id, CancellationToken cancellationToken);

    Task Update(Product product, CancellationToken cancellationToken);
    
    Task<Product> Delete(Guid id, CancellationToken cancellationToken);

}
