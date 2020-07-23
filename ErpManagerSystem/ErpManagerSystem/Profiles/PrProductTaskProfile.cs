using AutoMapper;
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
            CreateMap<PrProductTask, PrProductTaskDto>();
            CreateMap<PrProductTaskAddDto, PrProductTask>();
            CreateMap<PrProductTaskEditDto, PrProductTask>();
        }
    }
}