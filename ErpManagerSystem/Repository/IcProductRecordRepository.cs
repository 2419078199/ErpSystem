using IRepository;
using Model.Entitys;

namespace Repository
{
    public class IcProductRecordRepository : BaseRepository<IcProductRecord>, IIcProductRecordRepository
    {
        public IcProductRecordRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}