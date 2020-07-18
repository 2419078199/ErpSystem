using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class IcCommodityStockRepository : BaseRepository<IcCommodityStock>, IIcCommodityStockRepository
    {
        public IcCommodityStockRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
