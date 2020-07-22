<<<<<<< HEAD
﻿using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
>>>>>>> origin/RepObject

namespace Services
{
    public class PuCommodityCategoryServices : BaseServices<PuCommodityCategory>, IPuCommodityCategoryServices
    {
        private readonly IPuCommodityCategoryRepository _pucommoditycategoryrepository;

        public PuCommodityCategoryServices(IPuCommodityCategoryRepository pucommoditycategoryrepository)
        {
            _pucommoditycategoryrepository = pucommoditycategoryrepository;
            base.CurrentRepository = pucommoditycategoryrepository;
        }
<<<<<<< HEAD

        public async Task<PagedList<PuCommodityCategory>> PuCommodityCategoryPaged(PuCommodityCategoryParams PuCommodityCategoryParams)
        {
            IQueryable<PuCommodityCategory> PuCommodityCategoryinfo = _pucommoditycategoryrepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(PuCommodityCategoryParams.Name))
            {
                PuCommodityCategoryinfo = PuCommodityCategoryinfo.Where(a => a.Name.Contains(PuCommodityCategoryParams.Name));
            }
            return await PagedList<PuCommodityCategory>.CreatePagedList(PuCommodityCategoryinfo, PuCommodityCategoryParams.PageSize, PuCommodityCategoryParams.PageNum);
        }
=======
>>>>>>> origin/RepObject
    }
}
