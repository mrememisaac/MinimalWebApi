using AutoMapper;
using ProductsApi.Models;

namespace ProductsApi.Profiles
{
    public class PictureProfiles : Profile
    {
        public PictureProfiles()
        {
            CreateMap<Picture, Entities.Picture>().ReverseMap();
            CreateMap<CreatePicture, Entities.Picture>().ReverseMap();
            CreateMap<UpdatePicture, Entities.Picture>().ReverseMap();
        }
    }
}
