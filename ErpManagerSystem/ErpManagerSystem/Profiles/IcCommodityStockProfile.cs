using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class IcCommodityStockProfile : Profile
    {
        public IcCommodityStockProfile()
        {
            CreateMap<IcCommodityStock, IcCommodityStockDto>();
            CreateMap<IcCommodityStockAddDto, IcCommodityStock>();
            CreateMap<IcCommodityStockEditDto, IcCommodityStock>();
        }
    }
}