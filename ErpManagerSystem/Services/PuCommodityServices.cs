using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PuCommodityServices : BaseServices<PuCommodity>, IPuCommodityServices
    {
        private readonly IPuCommodityRepository _pucommodityrepository;

        public PuCommodityServices(IPuCommodityRepository pucommodityrepository)
        {
            _pucommodityrepository = pucommodityrepository;
            base.CurrentRepository = pucommodityrepository;
        }
    }
}
