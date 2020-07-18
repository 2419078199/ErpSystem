using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AcDepartmentRepository : BaseRepository<AcDepartment>, IAcDepartmentRepository
    {
        public AcDepartmentRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
