using System;
using System.Collections.Generic;
using System.Text;
using IRepository;
using Model.Entitys;

namespace Repository
{
    public class SlOrderRepository : BaseRepository<SlOrder>, ISlOrderRepository
    {
        public SlOrderRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
