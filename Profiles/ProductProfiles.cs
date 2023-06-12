using AutoMapper;
using ProductsApi.Models;

namespace ProductsApi.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles() 
        { 
            CreateMap<Product, Entities.Product>().ReverseMap();
            CreateMap<CreateProduct, Entities.Product>().ReverseMap();
            CreateMap<UpdateProduct, Entities.Product>().ReverseMap();

        }
    }
}
