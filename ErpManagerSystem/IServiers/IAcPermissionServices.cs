using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAcPermissionServices : IBaseServices<AcPermission>
    {
        Task<PagedList<AcPermission>> GetAcPermissionPaged(AcPermissionParams acPermissionParams);
    }
}