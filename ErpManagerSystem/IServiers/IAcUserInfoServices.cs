using System.Threading.Tasks;
using Common.Help;
using Model.Entitys;
using Model.Params;

namespace IServices
{
    public interface IAcUserInfoServices : IBaseServices<AcUserInfo>
    {
        Task<PagedList<AcUserInfo>> GetUserInfoPaged(AcUserInfoParams acUserInfoParams);
    }
}