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
    public class AcStaffServices : BaseServices<AcStaff>, IAcStaffServices
    {
        private readonly IAcStaffRepository _acstaffrepository;

        public AcStaffServices(IAcStaffRepository acstaffrepository)
        {
            _acstaffrepository = acstaffrepository;
            base.CurrentRepository = acstaffrepository;
        }
        public async Task<PagedList<AcStaff>> GetAcStaffPaged(AcStaffParams acStaffParams)
        {
            IQueryable<AcStaff> acStaffs = _acstaffrepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(acStaffParams.Name))
            {
                acStaffs = acStaffs.Where(a => a.Name.Contains(acStaffParams.Name));
            }
            return await PagedList<AcStaff>.CreatePagedList(acStaffs, acStaffParams.PageSize, acStaffParams.PageNum);
        }
    }
}
