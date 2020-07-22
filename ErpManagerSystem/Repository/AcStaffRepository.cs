using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AcStaffRepository : BaseRepository<AcStaff>, IAcStaffRepository
    {
        public AcStaffRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
