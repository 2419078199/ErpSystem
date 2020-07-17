using IRepository;
using Model.Entitys;

namespace Repository
{
    public class AcUserInfoRepository : BaseRepository<AcUserInfo>, IAcUserInfoInfoRepository
    {
        public AcUserInfoRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}