using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Repositories;
using System.Threading;

namespace ProductsApi.EndpointHandlers
{
    public static class ProductsHandler
    {
        public static async Task<Ok<IEnumerable<Product>>> GetProducts(IProductRepository repository, CancellationToken cancellationToken)
        {
            var products = await repository.List(cancellationToken: cancellationToken);
            return TypedResults.Ok(products.Select(p => p.Convert()));
        }

        public static async Task<Results<NotFound, NoContent>> DeleteProduct(Guid id, IProductRepository repository, CancellationToken cancellationToken)
        {
            var pdt = await repository.GetById(id, cancellationToken);
            if (pdt == null)
            {
                return TypedResults.NotFound();
            }
            await repository.Delete(id, cancellationToken);
            return TypedResults.NoContent();
        }

        public static async Task<Results<NotFound, NoContent>> UpdateProduct([FromBody] ProductsApi.Models.Product product, IProductRepository repository, CancellationToken cancellationToken)
        { 
            var pdt = await repository.GetById(product.Id, cancellationToken);
            if(pdt == null)
            {
                return TypedResults.NotFound();
            }
            await repository.Update(product.Convert(), cancellationToken);
            return TypedResults.NoContent();
        }

        public static async Task<CreatedAtRoute<Product>> CreateProduct([FromBody] ProductsApi.Models.Product product, IProductRepository repository, CancellationToken cancellationToken)
        {
            var newProduct = await repository.Add(product.Convert(), cancellationToken);
            return TypedResults.CreatedAtRoute(newProduct.Convert(), "GetProduct", new { id= newProduct.Id });
        }

        public static async Task<Results<NotFound, Ok<Product>>> GetProduct(Guid id, IProductRepository repository, CancellationToken cancellationToken)
        {
            var product = await repository.GetById(id, cancellationToken);
            if (product == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(product.Convert());
        }
    }
}
