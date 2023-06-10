namespace ProductsApi.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int Price { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public Picture Picture { get; set; }
}
