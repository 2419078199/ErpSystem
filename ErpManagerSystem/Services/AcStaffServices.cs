using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
