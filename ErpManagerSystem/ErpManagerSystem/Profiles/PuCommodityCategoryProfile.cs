using AutoMapper;
using Model;
using Model.Dtos.AddDto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class PuCommodityCategoryProfile : Profile
    {
        public PuCommodityCategoryProfile()
        {
            CreateMap<PuCommodityCategory, PuCommodityCategoryDto>();
            CreateMap<PuCommodityCategoryAddDto, PuCommodityCategory>();
            CreateMap<PuCommodityCategoryEditDto, PuCommodityCategory>();
        }
    }
}