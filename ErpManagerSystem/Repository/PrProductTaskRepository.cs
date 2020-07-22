using System;
using System.Collections.Generic;
using System.Text;
using IRepository;
using Model.Entitys;

namespace Repository
{
    public class PrProductTaskRepository : BaseRepository<PrProductTask>, IPrProductTaskRepository
    {
        public PrProductTaskRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
