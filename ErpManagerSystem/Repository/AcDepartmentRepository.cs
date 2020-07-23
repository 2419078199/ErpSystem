using IRepository;
using Model.Entitys;

namespace Repository
{
    public class AcDepartmentRepository : BaseRepository<AcDepartment>, IAcDepartmentRepository
    {
        public AcDepartmentRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}