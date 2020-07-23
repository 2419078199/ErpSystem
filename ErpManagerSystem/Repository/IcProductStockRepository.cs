using IRepository;
using Model.Entitys;

namespace Repository
{
    public class IcProductStockRepository : BaseRepository<IcProductStock>, IIcProductStockRepository
    {
        public IcProductStockRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}