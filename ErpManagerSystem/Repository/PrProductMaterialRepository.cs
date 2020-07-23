using IRepository;
using Model.Entitys;

namespace Repository
{
    public class PrProductMaterialRepository : BaseRepository<PrProductMaterial>, IPrProductMaterialRepository
    {
        public PrProductMaterialRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}