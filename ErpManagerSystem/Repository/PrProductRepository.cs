﻿using System;
using System.Collections.Generic;
using System.Text;
using IRepository;
using Model.Entitys;

namespace Repository
{
    public class PrProductRepository : BaseRepository<PrProduct>, IPrProductRepository
    {
        public PrProductRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
