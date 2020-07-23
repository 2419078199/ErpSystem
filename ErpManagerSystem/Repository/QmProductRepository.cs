using IRepository;
using Model.Entitys;

namespace Repository
{
    public class QmProductRepository : BaseRepository<QmProduct>, IQmProductRepository
    {
        public QmProductRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}