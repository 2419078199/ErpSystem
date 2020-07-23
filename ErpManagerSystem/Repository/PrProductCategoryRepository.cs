using IRepository;
using Model.Entitys;

namespace Repository
{
    public class PrProductCategoryRepository : BaseRepository<PrProductCategory>, IPrProductCategoryRepository
    {
        public PrProductCategoryRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}