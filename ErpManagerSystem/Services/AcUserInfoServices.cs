using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class AcUserInfServices : BaseServices<AcUserInfo>, IAcUserInfoServices
    {
        private readonly IAcUserInfoRepository _acuserinfoinforepository;

        public AcUserInfServices(IAcUserInfoRepository acuserinfoinforepository)
        {
            _acuserinfoinforepository = acuserinfoinforepository;
            base.CurrentRepository = acuserinfoinforepository;
        }

        public async Task<PagedList<AcUserInfo>> GetUserInfoPaged(AcUserInfoParams acuserinfoparams)
        {
            IQueryable<AcUserInfo> acUserInfos = _acuserinfoinforepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(acuserinfoparams.Account))
            {
                acUserInfos = acUserInfos.Where(a => a.Account.Contains(acuserinfoparams.Account));
            }
            return await PagedList<AcUserInfo>.CreatePagedList(acUserInfos, acuserinfoparams.PageSize, acuserinfoparams.PageNum);
        }
    }
}