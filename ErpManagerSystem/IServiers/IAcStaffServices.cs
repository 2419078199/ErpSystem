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
    public interface IAcStaffServices : IBaseServices<AcStaff>
    {
<<<<<<< HEAD
=======
        Task<PagedList<AcStaff>> GetAcStaffPaged(AcStaffParams acStaffParams);
>>>>>>> origin/RepObject
    }
}
