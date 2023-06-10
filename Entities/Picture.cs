namespace ProductsApi.Entities;

public sealed class Picture : Entity
{
    /// <summary>
    /// Bas64 Encoded Image string
    /// </summary>
    /// <value></value>
    public string Base64String { get; private set; }

    /// <summary>
    /// The Product this image belongs to
    /// </summary>
    /// <value></value>
    public Product Product { get; private set; }

    /// <summary>
    /// Added to allow Entity Framework materialize instances
    /// </summary>
    private Picture() { }

    /// <summary>
    /// Constructor privatised to ensure Picture instance is created safely
    /// </summary>
    /// <param name="id"></param>
    /// <param name="base64String"></param>
    /// <param name="product"></param>
    private Picture(Guid id, string base64String, Product product)
    {
        Id = id;
        Product = product;
        Base64String = base64String;
    }

    /// <summary>
    /// Creates a Picture instance after all safety checks have passed
    /// </summary>
    /// <param name="id"></param>
    /// <param name="base64String"></param>
    /// <param name="product"></param>
    /// <returns></returns>
    public static Picture Create(Guid id, string base64String, Product product)
    {
        if (String.IsNullOrWhiteSpace(base64String)) throw new ArgumentException("Parameter cannot be null, whitespace or empty string. It requires a valid base64 string", nameof(base64String));
        return new Picture(id, base64String, product);
    }
}