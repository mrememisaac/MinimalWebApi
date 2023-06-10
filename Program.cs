using ProductsApi.Data;
using ProductsApi.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseQueryTrackingBehavior(Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(config => config.WithOrigins("http://localhost:4000")
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseHttpsRedirection();


app.MapGet("/products", async (IProductRepository repository, CancellationToken cancellationToken) =>
{
    var products = await repository.List(cancellationToken: cancellationToken);
    return Results.Ok(products.Select(p => p.Convert()));
})
.Produces<IEnumerable<ProductsApi.Models.Product>>(StatusCodes.Status200OK)
.WithName("GetProducts");

app.MapGet("/products/{id:Guid}", async (Guid id, IProductRepository repository, CancellationToken cancellationToken) =>
{
    var product = await repository.GetById(id, cancellationToken);
    if (product == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product.Convert());
})
.Produces<ProductsApi.Models.ProductDetail>(StatusCodes.Status200OK)
.Produces<ProductsApi.Models.ProductDetail>(StatusCodes.Status404NotFound)
.WithName("GetProduct");

app.MapPost("/products", async([FromBody]ProductsApi.Models.Product product, IProductRepository repository, CancellationToken cancellationToken) =>
{
    var newProduct = await repository.Add(product.Convert(), cancellationToken);
    return Results.CreatedAtRoute($"/products/{newProduct.Id}", newProduct);
})
.Produces<ProductsApi.Models.Product>(StatusCodes.Status500InternalServerError)
.Produces<ProductsApi.Models.Product>(StatusCodes.Status400BadRequest)
.Produces<ProductsApi.Models.Product>(StatusCodes.Status201Created)
.WithName("CreateProduct");

app.MapPut("/products", async ([FromBody] ProductsApi.Models.Product product, IProductRepository repository, CancellationToken cancellationToken) =>
{ 
    var pdt = await repository.GetById(product.Id, cancellationToken);
    if(pdt == null)
    {
        return Results.NotFound();
    }
    var updatedProduct = await repository.Update(product.Convert(), cancellationToken);
    return Results.NoContent();
})
.Produces<ProductsApi.Models.Product>(StatusCodes.Status500InternalServerError)
.Produces<ProductsApi.Models.Product>(StatusCodes.Status400BadRequest)
.Produces<ProductsApi.Models.Product>(StatusCodes.Status204NoContent)
.WithName("UpdateProduct");

app.MapDelete("/products/{id:Guid}", async (Guid id, IProductRepository repository, CancellationToken cancellationToken) => {
    var pdt = await repository.GetById(id, cancellationToken);
    if (pdt == null)
    {
        return Results.NotFound();
    }
    await repository.Delete(id, cancellationToken);
    return Results.NoContent();
})
.Produces<ProductsApi.Models.Product>(StatusCodes.Status500InternalServerError)
.Produces<ProductsApi.Models.Product>(StatusCodes.Status400BadRequest)
.Produces<ProductsApi.Models.Product>(StatusCodes.Status204NoContent)
.WithName("DeleteProduct");

app.Run();