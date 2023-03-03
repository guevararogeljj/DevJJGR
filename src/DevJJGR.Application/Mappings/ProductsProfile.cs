using AutoMapper;
using DevJJGR.Application.Dto;

namespace DevJJGR.Application.Mappings
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<DevJJGR.Domain.Entities.Products, ProductsDTO>()
                .ForMember(dto => dto.ProductId, ent => ent.MapFrom(prop => prop.ProductId))
                .ForMember(dto => dto.ProductName, ent => ent.MapFrom(prop => prop.ProductName))
                .ForMember(dto => dto.Categories, ent => ent.MapFrom(prop => prop.Categories));

            CreateMap<ProductsDTO, DevJJGR.Domain.Entities.Products>()
                .ForMember(dto => dto.ProductId, ent => ent.MapFrom(prop => prop.ProductId))
                .ForMember(dto => dto.ProductName, ent => ent.MapFrom(prop => prop.ProductName))
                .ForMember(dto => dto.Categories, ent => ent.MapFrom(prop => prop.Categories));
        }
    }
}
