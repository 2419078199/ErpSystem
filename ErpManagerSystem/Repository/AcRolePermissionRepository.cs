using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AcRolePermissionRepository : BaseRepository<AcRolePermission>, IAcRolePermissionRepository
    {
        public AcRolePermissionRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
