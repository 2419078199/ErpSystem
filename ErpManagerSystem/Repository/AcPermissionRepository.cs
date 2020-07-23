using IRepository;
using Model.Entitys;

namespace Repository
{
    public class AcPermissionRepository : BaseRepository<AcPermission>, IAcPermissionRepository
    {
        public AcPermissionRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}