using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class PrProductCategoryProfile : Profile
    {
        public PrProductCategoryProfile()
        {
            CreateMap<PrProductCategory, PrProductCategoryDto>();
            CreateMap<PrProductCategoryAddDto, PrProductCategory>();
            CreateMap<PrProductCategoryEditDto, PrProductCategory>();
        }
    }
}