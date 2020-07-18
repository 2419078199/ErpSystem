using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AcRoleRepository : BaseRepository<AcRole>, IAcRoleRepository
    {
        public AcRoleRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
