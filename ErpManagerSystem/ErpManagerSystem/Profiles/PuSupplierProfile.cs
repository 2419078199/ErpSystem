using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class PuSupplierProfile : Profile
    {
        public PuSupplierProfile()
        {
            CreateMap<PuSupplier, PuSupplierDto>();
            CreateMap<PuSupplierAddDto, PuSupplier>();
            CreateMap<PuSupplierEditDto, PuSupplier>();
        }
    }
}