<<<<<<< HEAD
﻿using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
=======
﻿using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
>>>>>>> origin/RepObject

namespace IServices
{
    public interface IAcPermissionServices : IBaseServices<AcPermission>
    {
<<<<<<< HEAD
=======
        Task<PagedList<AcPermission>> GetAcPermissionPaged(AcPermissionParams acPermissionParams);
>>>>>>> origin/RepObject
    }
}
