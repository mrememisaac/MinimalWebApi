using MiniValidation;
using ProductsApi.Models;

namespace ProductsApi.EndpointFilters
{
    public class UpdateProductAnnotationsValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var model = context.GetArgument<UpdateProduct>(2);
            if (MiniValidator.TryValidate(model, out var validationErrors))
            {
                return TypedResults.ValidationProblem(validationErrors);
            }
            return await next(context);
        }
    }
}
