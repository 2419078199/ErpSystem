using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class SlRejectProfile : Profile
    {
        public SlRejectProfile()
        {
            CreateMap<SlReject, SlRejectDto>();
            CreateMap<SlRejectAddDto, SlReject>();
        }
    }
}