using AutoMapper;
<<<<<<< HEAD
using Model.Dtos.AddDto;
using Model.Dtos.Dto;
using Model.Dtos.EditDto;
=======
using Model.Dtos.Dto;
>>>>>>> origin/RepObject
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpManagerSystem.Profiles
{
    public class PuSupplierProfile:Profile
    {
        public PuSupplierProfile() {
            CreateMap<PuSupplier, PuSupplierDto>();
<<<<<<< HEAD
            CreateMap<PuSupplierAddDto, PuSupplier>();
            CreateMap<PuSupplierEditDto, PuSupplier>();
=======
>>>>>>> origin/RepObject
        }
    }
}
