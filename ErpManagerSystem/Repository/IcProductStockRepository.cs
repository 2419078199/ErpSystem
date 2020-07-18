using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class IcProductStockRepository : BaseRepository<IcProductStock>, IIcProductStockRepository
    {
        public IcProductStockRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
