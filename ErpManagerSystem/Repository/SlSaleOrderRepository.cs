using IRepository;
using Model.Entitys;

namespace Repository
{
    public class SlSaleOrderRepository : BaseRepository<SlSaleOrder>, ISlSaleOrderRepository
    {
        public SlSaleOrderRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}