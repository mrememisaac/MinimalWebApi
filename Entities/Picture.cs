namespace MinimalWebApi.Entities;

public sealed class Picture : Entity
{
    public string Base64String { get; }

    public Guid ProductId { get; }

    private Picture(Guid id, string base64String, Guid productId) : base(id)
    {
        ProductId = productId;
        Base64String = base64String;
    }

    public static Picture Create(Guid id, string base64String, Guid productId)
    {
        if (productId == Guid.Empty) throw new ArgumentException("ProductId must be a valid Guid", nameof(productId));
        if (String.IsNullOrWhiteSpace(base64String)) throw new ArgumentException("Parameter cannot be null, whitespace or empty string. It requires a valid base64 string", nameof(base64String));
        return new Picture(id, base64String, productId);
    }
}