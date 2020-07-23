using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAcStaffServices : IBaseServices<AcStaff>
    {
        Task<PagedList<AcStaff>> GetAcStaffPaged(AcStaffParams acStaffParams);
    }
}