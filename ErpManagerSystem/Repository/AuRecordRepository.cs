using IRepository;
using Model.Entitys;

namespace Repository
{
    public class AuRecordRepository : BaseRepository<AuRecord>, IAuRecordRepository
    {
        public AuRecordRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}