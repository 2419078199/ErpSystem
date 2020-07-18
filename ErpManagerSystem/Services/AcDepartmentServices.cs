using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
   public class AcDepartmentServices : BaseServices<AcDepartment>, IAcDepartmentServices
    {
        private readonly IAcDepartmentRepository _acdepartmentrepository;

        public AcDepartmentServices(IAcDepartmentRepository acdepartmentrepository)
        {
            _acdepartmentrepository = acdepartmentrepository;
            base.CurrentRepository = acdepartmentrepository;
        }
    }
}
