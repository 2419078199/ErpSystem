using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class SlCustomerProfile : Profile
    {
        public SlCustomerProfile()
        {
            CreateMap<SlCustomer, SlCustomerDto>();
            CreateMap<SlCustomerDto, SlCustomer>();
            CreateMap<SlCustomerAddDto, SlCustomer>();
            CreateMap<SlCustomerEditdDto, SlCustomer>();
        }
    }
}