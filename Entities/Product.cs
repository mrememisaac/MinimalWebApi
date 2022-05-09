namespace MinimalWebApi.Entities;

public sealed class Product : Entity
{
    public string Name { get; }

    public string Description { get; }

    public int Price { get; }

    private List<Picture> Pictures { get; } = new List<Picture>();

    public IReadOnlyCollection<Picture> PicturesCollection => Pictures.AsReadOnly();

    private Product(Guid id, string name, string description, int price, IEnumerable<Picture> pictures) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Pictures.AddRange(pictures);
    }

    public static Product Create(Guid id, string name, string description, int price, IEnumerable<Picture> pictures)
    {
        if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException("Provide a valid name", nameof(name));
        if (String.IsNullOrWhiteSpace(description)) throw new ArgumentException("Provide a valid description", nameof(description));
        if (price < 500) throw new ArgumentException("Price cannot be less than 500", nameof(price));
        return new Product(id, name, description, price, pictures);
    }
}