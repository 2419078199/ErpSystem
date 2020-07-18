using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class IcProductRecordRepository : BaseRepository<IcProductRecord>, IIcProductRecordRepository
    {
        public IcProductRecordRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
