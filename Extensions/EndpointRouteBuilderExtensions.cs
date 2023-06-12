using ProductsApi.EndpointFilters;
using ProductsApi.EndpointHandlers;

namespace ProductsApi.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterProductEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var productsEndpoints = endpointRouteBuilder.MapGroup("/products");
            var productsWithGuidEndpoints = endpointRouteBuilder.MapGroup("/products/{id:guid}");

            productsEndpoints.MapGet("", ProductsHandler.GetProducts)
                .Produces<IEnumerable<ProductsApi.Models.Product>>(StatusCodes.Status200OK)
                .WithName("GetProducts");

            productsWithGuidEndpoints.MapDelete("", ProductsHandler.DeleteProduct)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status500InternalServerError)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status400BadRequest)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status204NoContent)
                .WithName("DeleteProduct");

            productsWithGuidEndpoints.MapPut("", ProductsHandler.UpdateProduct)
                .AddEndpointFilter<UpdateProductAnnotationsValidationFilter>()
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status500InternalServerError)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status400BadRequest)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status204NoContent)
                .WithName("UpdateProduct");

            productsEndpoints.MapPost("", ProductsHandler.CreateProduct)
                .AddEndpointFilter<CreateProductAnnotationsValidationFilter>()
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status500InternalServerError)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status400BadRequest)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status201Created)
                .WithName("CreateProduct");

            productsWithGuidEndpoints.MapGet("", ProductsHandler.GetProduct)
                .Produces<ProductsApi.Models.ProductDetail>(StatusCodes.Status200OK)
                .Produces<ProductsApi.Models.ProductDetail>(StatusCodes.Status404NotFound)
                .WithName("GetProduct");
        }
    }
}
