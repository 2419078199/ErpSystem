using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAcUserInfoServices : IBaseServices<AcUserInfo>
    {
        Task<PagedList<AcUserInfo>> GetUserInfoPaged(AcUserInfoParams acUserInfoParams);
    }
}