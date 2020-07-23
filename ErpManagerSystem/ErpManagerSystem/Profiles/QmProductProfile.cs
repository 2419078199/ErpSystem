using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class QmProductProfile : Profile
    {
        public QmProductProfile()
        {
            CreateMap<QmProduct, QmProductDto>();
            CreateMap<QmProductAddDto, QmProduct>();
            CreateMap<QmProductEditDto, QmProduct>();
        }
    }
}