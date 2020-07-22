using System;
using System.Collections.Generic;
using System.Text;
using IRepository;
using Model.Entitys;

namespace Repository
{
    public class SysConfigItemRepository : BaseRepository<SysConfigItem>, ISysConfigItemRepository
    {
        public SysConfigItemRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
