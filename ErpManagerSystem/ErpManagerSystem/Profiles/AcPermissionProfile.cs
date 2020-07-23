using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class AcPermissionProfile : Profile
    {
        public AcPermissionProfile()
        {
            CreateMap<AcPermission, AcPermissionDto>();
            CreateMap<AcPermissionAddDto, AcPermission>();
            CreateMap<AcPermissionEditDto, AcPermission>();
        }
    }
}