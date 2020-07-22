using System;
using System.Collections.Generic;
using System.Text;
using IRepository;
using Model.Entitys;

namespace Repository
{
    public class ViewUserPermissionRepository : BaseRepository<ViewUserPermission>, IViewUserPermissionRepository
    {
        public ViewUserPermissionRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
