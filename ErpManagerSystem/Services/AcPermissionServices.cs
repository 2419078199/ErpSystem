using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
﻿using Common.Help;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

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


        public async Task<PagedList<AcPermission>> GetAcPermissionPaged(AcPermissionParams acPermissionParams)
        {
            IQueryable<AcPermission> acPermission = _acpermissionrepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(acPermissionParams.Name))
            {
                acPermission = acPermission.Where(a => a.Name.Contains(acPermissionParams.Name));
            }
            return await PagedList<AcPermission>.CreatePagedList(acPermission, acPermissionParams.PageSize, acPermissionParams.PageNum);
        }
    }
}
