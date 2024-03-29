namespace ProductsApi.Models;

public class Picture
{
    public Guid Id { get; set; }

    public string Base64String { get; set; } = string.Empty;

    public Guid ProductId { get; set; }

    public string CreatedBy { get; set; } = string.Empty;
}