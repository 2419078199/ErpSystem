using IRepository;
using Model.Entitys;

namespace Repository
{
    public class AcRolePermissionRepository : BaseRepository<AcRolePermission>, IAcRolePermissionRepository
    {
        public AcRolePermissionRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}