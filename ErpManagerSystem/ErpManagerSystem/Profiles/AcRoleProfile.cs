using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class AcRoleProfile : Profile
    {
        public AcRoleProfile()
        {
            CreateMap<AcRole, AcRoleDto>();
            CreateMap<AcRoleAddDto, AcRole>();
            CreateMap<AcRoleEditDto, AcRole>();
        }
    }
}