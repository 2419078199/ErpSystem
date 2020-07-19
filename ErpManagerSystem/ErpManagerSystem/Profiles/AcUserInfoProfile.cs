using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class AcUserInfoProfile : Profile
    {
        public AcUserInfoProfile()
        {
            CreateMap<AcUserInfo, AcUserInfoDto>();
            CreateMap<AcUserInfoAddDto, AcUserInfo>();
            CreateMap<AcUserInfoEditDto, AcUserInfo>();
        }
    }
}