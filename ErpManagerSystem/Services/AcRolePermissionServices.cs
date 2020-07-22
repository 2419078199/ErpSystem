using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AcRolePermissionServices : BaseServices<AcRolePermission>, IAcRolePermissionServices
    {
        private readonly IAcRolePermissionRepository _acrolepermissionrepository;

        public AcRolePermissionServices(IAcRolePermissionRepository acrolepermissionrepository)
        {
            _acrolepermissionrepository = acrolepermissionrepository;
            base.CurrentRepository = acrolepermissionrepository;
        }
    }
}
