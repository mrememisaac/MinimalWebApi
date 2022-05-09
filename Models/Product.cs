namespace MinimalWebApi.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int Price { get; set; }

    public List<Picture> Pictures { get; set; } = new List<Picture>();
}
