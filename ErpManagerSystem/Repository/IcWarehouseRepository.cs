using IRepository;
using Model.Entitys;

namespace Repository
{
    public class IcWarehouseRepository : BaseRepository<IcWarehouse>, IIcWarehouseRepository
    {
        public IcWarehouseRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}