using IRepository;
using Model.Entitys;

namespace Repository
{
    public class PuCommodityCategoryRepository : BaseRepository<PuCommodityCategory>, IPuCommodityCategoryRepository
    {
        public PuCommodityCategoryRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}