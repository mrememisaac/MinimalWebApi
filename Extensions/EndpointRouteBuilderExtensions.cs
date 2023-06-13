using ProductsApi.EndpointFilters;
using ProductsApi.EndpointHandlers;

namespace ProductsApi.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterProductEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var productsEndpoints = endpointRouteBuilder.MapGroup("/products").RequireAuthorization()
                .WithOpenApi();

            productsEndpoints.MapGet("", ProductsHandler.GetProducts)
                .Produces<IEnumerable<ProductsApi.Models.Product>>(StatusCodes.Status200OK)
                .WithSummary("Provides a list of products")
                .WithDescription("Provides a list of products. This list can be paged")
                .WithName("GetProducts");
        
            productsEndpoints.MapPost("", ProductsHandler.CreateProduct)
                .RequireAuthorization("ProductCreator")
                .AddEndpointFilter<CreateProductAnnotationsValidationFilter>()
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status500InternalServerError)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status400BadRequest)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status201Created)
                .WithSummary("Create a product")
                .WithDescription("Use this endpoint to create a product. You must be a member of the Product Creator role")
                .WithName("CreateProduct");

            var productsWithGuidEndpoints = endpointRouteBuilder.MapGroup("/products/{id:guid}").RequireAuthorization()
                .WithOpenApi();
            
            productsWithGuidEndpoints.MapDelete("", ProductsHandler.DeleteProduct)
                .RequireAuthorization("ProductDeleter")
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status500InternalServerError)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status400BadRequest)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status204NoContent)
                .WithSummary("Delete a product")
                .WithDescription("Use this endpoint to delete a product. You must be a member of the Product Deleter role")
                .WithName("DeleteProduct");

            productsWithGuidEndpoints.MapPut("", ProductsHandler.UpdateProduct)
                .RequireAuthorization("ProductUpdater")
                .AddEndpointFilter<UpdateProductAnnotationsValidationFilter>()
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status500InternalServerError)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status400BadRequest)
                .Produces<ProductsApi.Models.Product>(StatusCodes.Status204NoContent)
                .WithSummary("Update a product")
                .WithDescription("Use this endpoint to update a product. You must be a member of the Product Updater role")
                .WithName("UpdateProduct");

            productsWithGuidEndpoints.MapGet("", ProductsHandler.GetProduct)
                .AllowAnonymous()
                .Produces<ProductsApi.Models.ProductDetail>(StatusCodes.Status200OK)
                .Produces<ProductsApi.Models.ProductDetail>(StatusCodes.Status404NotFound)
                .WithName("GetProduct");
        }
    }
}
