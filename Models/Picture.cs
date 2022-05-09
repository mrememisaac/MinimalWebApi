namespace MinimalWebApi.Models;

public class Picture
{
    public Guid Id { get; set; }

    public string Base64String { get; set; } = string.Empty;

    public Guid ProductId { get; set; }
}