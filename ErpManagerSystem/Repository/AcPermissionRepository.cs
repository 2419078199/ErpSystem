using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AcPermissionRepository : BaseRepository<AcPermission>, IAcPermissionRepository
    {
        public AcPermissionRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
