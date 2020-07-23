using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class IcProductStockProfile : Profile
    {
        public IcProductStockProfile()
        {
            CreateMap<IcProductStock, IcProductStockDto>();
            CreateMap<IcProductStockAddDto, IcProductStock>();
            CreateMap<IcProductStockEditDto, IcProductStock>();
        }
    }
}