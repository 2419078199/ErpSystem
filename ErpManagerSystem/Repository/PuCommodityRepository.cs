using System;
using System.Collections.Generic;
using System.Text;
using IRepository;
using Model.Entitys;

namespace Repository
{
    public class PuCommodityRepository : BaseRepository<PuCommodity>, IPuCommodityRepository
    {
        public PuCommodityRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
