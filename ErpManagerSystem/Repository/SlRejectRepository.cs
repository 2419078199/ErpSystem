using System;
using System.Collections.Generic;
using System.Text;
using IRepository;
using Model.Entitys;

namespace Repository
{
    public class SlRejectRepository : BaseRepository<SlReject>, ISlRejectRepository
    {
        public SlRejectRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
