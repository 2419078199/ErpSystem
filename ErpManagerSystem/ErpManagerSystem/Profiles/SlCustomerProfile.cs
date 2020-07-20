using AutoMapper;
using Model.Dtos.Dto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class SlCustomerProfile : Profile
    {
        public SlCustomerProfile()
        {
            CreateMap<SlCustomer, SlCustomerDto>();
            CreateMap<SlCustomerDto, SlCustomer>();
        }
    }
}