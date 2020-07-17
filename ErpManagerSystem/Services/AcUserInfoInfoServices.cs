using System.Linq;
using System.Threading.Tasks;
using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;

namespace Services
{
    public class AcUserInfoInfoServices : BaseServices<AcUserInfo>, IAcUserInfoServices
    {
        private readonly IAcUserInfoInfoRepository _acUserInfoInfoRepository;

        public AcUserInfoInfoServices(IAcUserInfoInfoRepository acUserInfoInfoRepository)
        {
            _acUserInfoInfoRepository = acUserInfoInfoRepository;
            base.CurrentRepository = acUserInfoInfoRepository;
        }

        public async Task<PagedList<AcUserInfo>> GetUserInfoPaged(AcUserInfoParams acUserInfoParams)
        {
            IQueryable<AcUserInfo> acUserInfos = _acUserInfoInfoRepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(acUserInfoParams.Account))
            {
                acUserInfos = acUserInfos.Where(a => a.Account.Contains(acUserInfoParams.Account));
            }
            return await PagedList<AcUserInfo>.CreatePagedList(acUserInfos, acUserInfoParams.PageSize, acUserInfoParams.PageNum);
        }
    }
}