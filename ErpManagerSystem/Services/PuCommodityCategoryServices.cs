using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
