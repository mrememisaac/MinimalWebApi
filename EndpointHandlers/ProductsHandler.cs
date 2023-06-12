using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Repositories;
using System.Threading;

namespace ProductsApi.EndpointHandlers
{
    public class ProductsHandler
    {
        public static async Task<Ok<IEnumerable<Product>>> GetProducts(IProductRepository repository, 
            CancellationToken cancellationToken,
            IMapper mapper,
            ILogger<ProductsHandler> logger)
        {
            logger.LogInformation($"Getting Products");
            var products = await repository.List(cancellationToken: cancellationToken);
            return TypedResults.Ok(mapper.Map<IEnumerable<Models.Product>>(products));
        }

        public static async Task<Results<NotFound, NoContent>> DeleteProduct(Guid id, IProductRepository repository, CancellationToken cancellationToken, ILogger<ProductsHandler> logger)
        {
            var pdt = await repository.GetById(id, cancellationToken);
            if (pdt == null)
            {
                return TypedResults.NotFound();
            }
            await repository.Delete(id, cancellationToken);
            return TypedResults.NoContent();
        }

        public static async Task<Results<NotFound, NoContent>> UpdateProduct(Guid id, [FromBody] UpdateProduct product, 
            IProductRepository repository, 
            CancellationToken cancellationToken, 
            IMapper mapper,
            ILogger<ProductsHandler> logger)
        { 
            var pdt = await repository.GetById(id, cancellationToken);
            if(pdt == null)
            {
                return TypedResults.NotFound();
            }
            await repository.Update(mapper.Map<Entities.Product>(pdt), cancellationToken);
            return TypedResults.NoContent();
        }

        public static async Task<CreatedAtRoute<Product>> CreateProduct([FromBody] CreateProduct product, 
            IProductRepository repository, 
            CancellationToken cancellationToken,
            IMapper mapper,
            ILogger<ProductsHandler> logger)
        {
            var entityProduct = await repository.Add(mapper.Map<Entities.Product>(product), cancellationToken);
            return TypedResults.CreatedAtRoute(mapper.Map<Product>(entityProduct), "GetProduct", new { id= entityProduct.Id });
        }

        public static async Task<Results<NotFound, Ok<Product>>> GetProduct(Guid id, 
            IProductRepository repository, 
            CancellationToken cancellationToken, 
            IMapper mapper,
            ILogger<ProductsHandler> logger)
        {
            var product = await repository.GetById(id, cancellationToken);
            if (product == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(mapper.Map<Models.Product>(product));
        }
    }
}
