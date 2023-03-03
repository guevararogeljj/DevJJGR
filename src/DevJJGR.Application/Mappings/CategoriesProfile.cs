using AutoMapper;
using DevJJGR.Application.Dto;

namespace DevJJGR.Application.Mappings
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<DevJJGR.Domain.Entities.Categories, CategoriesDTO>()
               .ForMember(dto => dto.CategoryId, ent => ent.MapFrom(prop => prop.CategoryId))
               .ForMember(dto => dto.CategoryName, ent => ent.MapFrom(prop => prop.Name));
        }
    }
}
