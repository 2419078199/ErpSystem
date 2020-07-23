using IRepository;
using Model.Entitys;

namespace Repository
{
    public class IcCommodityRecordRepository : BaseRepository<IcCommodityRecord>, IIcCommodityRecordRepository
    {
        public IcCommodityRecordRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}