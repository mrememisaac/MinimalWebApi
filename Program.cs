using ProductsApi.Data;
using ProductsApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Extensions;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseQueryTrackingBehavior(Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddCors();

builder.Services.AddProblemDetails();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("ProductCreator", policy => policy.RequireRole("ProductCreator"))
    .AddPolicy("ProductUpdater", policy => policy.RequireRole("ProductUpdater"))
    .AddPolicy("ProductDeleter", policy => policy.RequireRole("ProductDeleter"));

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

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.RegisterProductEndpoints();

app.Run();