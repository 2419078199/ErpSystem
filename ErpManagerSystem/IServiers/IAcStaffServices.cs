using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAcStaffServices : IBaseServices<AcStaff>
    {
        Task<PagedList<AcStaff>> GetAcStaffPaged(AcStaffParams acStaffParams);
    }
}
