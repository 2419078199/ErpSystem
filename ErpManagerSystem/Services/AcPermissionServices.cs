using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AcPermissionServices : BaseServices<AcPermission>, IAcPermissionServices
    {
        private readonly IAcPermissionRepository _acpermissionrepository;
        public AcPermissionServices(IAcPermissionRepository acpermissionrepository)
        {
            _acpermissionrepository = acpermissionrepository;
            base.CurrentRepository = acpermissionrepository;
        }
    }
}
