using AutoMapper;
using Model.Dtos.AddDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class SlSaleOrderProfile : Profile
    {
        public SlSaleOrderProfile()
        {
            CreateMap<SlSaleOrderAddDto, SlSaleOrder>();
        }
    }
}