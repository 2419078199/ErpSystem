using System;
using System.Collections.Generic;
using System.Text;
using IRepository;
using Model.Entitys;

namespace Repository
{
    public class PuOrderRepository : BaseRepository<PuOrder>, IPuOrderRepository
    {
        public PuOrderRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
