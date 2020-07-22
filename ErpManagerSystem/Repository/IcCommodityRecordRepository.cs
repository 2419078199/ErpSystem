using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class IcCommodityRecordRepository : BaseRepository<IcCommodityRecord>, IIcCommodityRecordRepository
    {
        public IcCommodityRecordRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
