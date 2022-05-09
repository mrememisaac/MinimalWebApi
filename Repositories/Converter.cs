namespace MinimalWebApi.Repositories;

public static class Converter
{
    public static Models.Picture Convert(this Entities.Picture picture)
    {
        return new Models.Picture
        {
            Id = picture.Id,
            Base64String = picture.Base64String,
            ProductId = picture.ProductId
        };
    }

    public static Entities.Picture Convert(this Models.Picture picture)
    {
        return Entities.Picture.Create(picture.Id, picture.Base64String, picture.ProductId);
    }

    public static Models.Product Convert(this Entities.Product product)
    {
        return new Models.Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Pictures = product.PicturesCollection.Select(pic => Convert(pic)).ToList()
        };
    }

    public static Entities.Product Convert(this Models.Product product)
    {
        return Entities.Product.Create(product.Id, product.Name, product.Description, product.Price, product.Pictures.Select(p => Convert(p)));
    }

}
