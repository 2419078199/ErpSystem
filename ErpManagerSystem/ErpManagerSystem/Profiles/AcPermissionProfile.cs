using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.EditDto;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpManagerSystem.Profiles
{
    public class AcPermissionProfile:Profile
    {
        public AcPermissionProfile()
        {
            CreateMap<AcPermission, AcPermissionDto>();
            CreateMap<AcPermissionAddDto, AcPermission>();
            CreateMap<AcPermissionEditDto, AcPermission>();
        }
    }
}
