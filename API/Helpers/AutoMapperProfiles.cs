using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>();
        CreateMap<Product, ProductCardDto>();
        CreateMap<ProductPhoto, PhotoDto>();
        CreateMap<Review, ReviewDto>();
        CreateMap<Product, ProductDetailDto>();
    }
}
