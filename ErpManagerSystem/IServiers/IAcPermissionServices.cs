using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAcPermissionServices : IBaseServices<AcPermission>
    {
        Task<PagedList<AcPermission>> GetAcPermissionPaged(AcPermissionParams acPermissionParams);
    }
}
