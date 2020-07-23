using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace ErpManagerSystem.Profiles
{
    public class PuCommodityProfile:Profile
    {
        public PuCommodityProfile() {
            CreateMap<PuCommodity, PuCommodityDto>();
            CreateMap<PuCommodityAddDto, PuCommodity>();
            CreateMap<PuCommodityEditDto, PuCommodity>();
        }
    }
}
