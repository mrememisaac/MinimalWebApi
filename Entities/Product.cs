namespace ProductsApi.Entities;

public sealed class Product : Entity
{
    /// <summary>
    /// Product Name
    /// </summary>
    /// <value></value>
    public string Name { get; private set; }

    /// <summary>
    /// Product Description
    /// </summary>
    /// <value></value>
    public string Description { get; private set; }

    /// <summary>
    /// Product Price.
    /// </summary>
    /// <value></value>
    public int Price { get; private set; }

    /// <summary>
    /// Product Pictures
    /// </summary>
    /// <typeparam name="Picture"></typeparam>
    /// <returns>List<Entities.Picture></returns>
    private List<Picture> Pictures { get; set; } = new List<Picture>();

    public IReadOnlyCollection<Picture> PicturesCollection => Pictures.AsReadOnly();

    /// <summary>
    /// Private constructor added to allow EF hydrate instances
    /// </summary>
    private Product() { }

    /// <summary>
    /// Constructor privatised to ensure can only be called by the Create static method after all safety checks have passed
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="price"></param>
    private Product(Guid id, string name, string description, int price, string createdBy)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        CreatedBy = createdBy;
        DateCreated = DateTimeOffset.Now;
    }

    /// <summary>
    /// Creates a product instance after satisfying all safety checks.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="price"></param>
    /// <returns>A Product if all goes well. Else throws an exception</returns>
    public static Product Create(Guid id, string name, string description, int price, string createdBy)
    {
        if (String.IsNullOrWhiteSpace(name)) throw new ArgumentException("Provide a valid name", nameof(name));
        if (String.IsNullOrWhiteSpace(description)) throw new ArgumentException("Provide a valid description", nameof(description));
        if (price < 500) throw new ArgumentException("Price cannot be less than 500", nameof(price));
        if (String.IsNullOrWhiteSpace(createdBy)) throw new ArgumentException("Creator username required", nameof(createdBy));
        return new Product(id, name, description, price, createdBy);
    }

    /// <summary>
    /// Adds a product picture
    /// </summary>
    /// <param name="picture"></param>
    public void AddPicture(Picture picture)
    {
        Pictures.Add(picture);
    }
}