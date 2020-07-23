using IRepository;
using Model.Entitys;

namespace Repository
{
    public class IcCommodityStockRepository : BaseRepository<IcCommodityStock>, IIcCommodityStockRepository
    {
        public IcCommodityStockRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}