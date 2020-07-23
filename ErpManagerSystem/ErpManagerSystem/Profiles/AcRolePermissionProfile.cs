﻿using AutoMapper;
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpManagerSystem.Profiles
{
    public class AcRolePermissionProfile:Profile
    {
        public AcRolePermissionProfile()
        {
            CreateMap<AcRolePermission, AcRolePermissionDto>();
            CreateMap<AcRolePermissionAddDto, AcRolePermission>();
            CreateMap<AcRolePermissionEditDto, AcRolePermission>();
        }
    }
}
