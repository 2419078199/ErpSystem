using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class PrProductMaterialProfile : Profile
    {
        public PrProductMaterialProfile()
        {
            CreateMap<PrProductMaterial, PrProductMaterialDto>();
            CreateMap<PrProductMaterialAddDto, PrProductMaterial>();
            CreateMap<PrProductMaterialEditDto, PrProductMaterial>();
        }
    }
}