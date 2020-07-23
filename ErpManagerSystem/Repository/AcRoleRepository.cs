using IRepository;
using Model.Entitys;

namespace Repository
{
    public class AcRoleRepository : BaseRepository<AcRole>, IAcRoleRepository
    {
        public AcRoleRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}