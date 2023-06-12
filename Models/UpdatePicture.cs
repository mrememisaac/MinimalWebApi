namespace ProductsApi.Models;

public class UpdatePicture
{
    public string Base64String { get; set; } = string.Empty;

    public Guid ProductId { get; set; }
}