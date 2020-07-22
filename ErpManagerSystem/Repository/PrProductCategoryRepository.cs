using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class PrProductCategoryRepository : BaseRepository<PrProductCategory>, IPrProductCategoryRepository
    {
        public PrProductCategoryRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
