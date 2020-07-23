using IRepository;
using Model.Entitys;

namespace Repository
{
    public class AcStaffRepository : BaseRepository<AcStaff>, IAcStaffRepository
    {
        public AcStaffRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}