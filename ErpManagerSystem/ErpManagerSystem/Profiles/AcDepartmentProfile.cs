using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class AcDepartmentProfile : Profile
    {
        public AcDepartmentProfile()
        {
            CreateMap<AcDepartment, AcDepartmentDto>();
            CreateMap<AcDepartmentAddDto, AcDepartment>();
            CreateMap<AcDepartmentEditDto, AcDepartment>();
        }
    }
}
