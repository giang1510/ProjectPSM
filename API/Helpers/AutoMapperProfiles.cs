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
        CreateMap<AppUser, RegisterDto>();
        CreateMap<Product, ProductCardDto>();
        CreateMap<ProductPhoto, PhotoDto>();
        CreateMap<Review, ReviewDto>();
        CreateMap<Product, ProductDetailDto>();
        // TODO Use constant from a file instead of plain values
        CreateMap<ProductEntryDto, Product>()
            .ForMember(
                dest => dest.Category,
                opt =>
                    opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.Category) ? "Other" : src.Category.ToUpper()
                    )
            )
            .ForMember(dest => dest.Photos, opt => opt.Ignore());
    }
}
