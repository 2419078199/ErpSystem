using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class SlOrderProfile : Profile
    {
        public SlOrderProfile()
        {
            CreateMap<SlOrder, SlOrderDto>()
                .ForMember(dto => dto.CustomerName, opt => opt.MapFrom(entity => entity.Customer.Name))
                .ForMember(dto => dto.ProductName, opt => opt.MapFrom(entity => entity.Product.Name));
            CreateMap<SlOrderAddDto, SlOrder>();
            CreateMap<SlOrderEditDto, SlOrder>();
        }
    }
}