using AutoMapper;
using Model.Dtos.Dto;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpManagerSystem.Profiles
{
    public class PowerAcPermissionProfile:Profile
    {
        public PowerAcPermissionProfile()
        {
            CreateMap<AcPermission, PowerAcPermissionDto>();
        }
    }
}
