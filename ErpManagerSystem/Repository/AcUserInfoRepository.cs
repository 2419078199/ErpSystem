using IRepository;
using Model.Entitys;

namespace Repository
{
    public class AcUserInfoRepository : BaseRepository<AcUserInfo>, IAcUserInfoRepository
    {
        public AcUserInfoRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}