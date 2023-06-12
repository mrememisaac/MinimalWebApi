namespace ProductsApi.Models;

public class CreatePicture
{
    public string Base64String { get; set; } = string.Empty;

    public Guid ProductId { get; set; }
}
