using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class SlOrderProfile:Profile
    {
        public SlOrderProfile()
        {
            CreateMap<SlOrder, SlOrderDto>();
            CreateMap<SlOrderAddDto, SlOrder>();
            CreateMap<SlOrderEditDto, SlOrder>();
        }
    }
}