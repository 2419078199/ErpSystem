using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class PuOrderProfile : Profile
    {
        public PuOrderProfile()
        {
            CreateMap<PuOrder, PuOrderDto>();
            CreateMap<PuOrderAddDto, PuOrder>();
            CreateMap<PuOrderEditDto, PuOrder>();
        }
    }
}