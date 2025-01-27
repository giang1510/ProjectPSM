using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

/// <summary>
/// Configure auto mapping between entities and dtos
/// </summary>
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
