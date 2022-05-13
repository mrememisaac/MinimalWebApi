using Microsoft.EntityFrameworkCore;
using MinimalWebApi.Entities;

namespace MinimalWebApi.Data;

public static class Seeder
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<Product>().HasData(Products);
    }

    private static List<Product> Products => new()
    {
        Product.Create(Guid.NewGuid(), "Thinkpad Lenovo", "Thinkpad Business Grade Laptop", 214650, "seeder"),
        Product.Create(Guid.NewGuid(), "MacBook Pro", "MacBook Pro Laptop", 523849, "seeder"),
        Product.Create(Guid.NewGuid(), "HP GL9 Tower Server", "Small Business Server", 492147, "seeder")
    };
}