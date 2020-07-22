using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AcRoleServices : BaseServices<AcRole>, IAcRoleServices
    {
        private readonly IAcRoleRepository _acrolerepository;

        public AcRoleServices(IAcRoleRepository acrolerepository)
        {
            _acrolerepository = acrolerepository;
            base.CurrentRepository = acrolerepository;
        }
    }
}
