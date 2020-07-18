using System;
using System.Collections.Generic;
using System.Text;
using IRepository;
using Model.Entitys;

namespace Repository
{
    public class QmCommodityRepository : BaseRepository<QmCommodity>, IQmCommodityRepository
    {
        public QmCommodityRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
