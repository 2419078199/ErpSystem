using IRepository;
using Model.Entitys;

namespace Repository
{
    public class SlCustomerRepository : BaseRepository<SlCustomer>, ISlCustomerRepository
    {
        public SlCustomerRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}