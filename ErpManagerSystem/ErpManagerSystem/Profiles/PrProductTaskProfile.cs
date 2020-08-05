using AutoMapper;
using IServices;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class PrProductTaskProfile : Profile
    {
        public PrProductTaskProfile()
        {
            CreateMap<PrProductTask, PrProductTaskDto>()
                .ForMember(dest=> dest.ProductName, opt => opt.MapFrom(src => $"{src.ProductNavigation.Name}"))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => $"{src.Product.Name}"))
                 .ForMember(dest => dest.OperatorName, opt => opt.MapFrom(src => $"{src.Operator.Name}"));
            CreateMap<PrProductTaskAddDto, PrProductTask>();
            CreateMap<PrProductTaskEditDto, PrProductTask>();
        }
    }
}