using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class IcCommodityStockServices : BaseServices<IcCommodityStock>, IIcCommodityStockServices
    {
        private readonly IIcCommodityStockRepository _iiccommoditystockrepository;

        public IcCommodityStockServices(IIcCommodityStockRepository iiccommoditystockrepository)
        {
            _iiccommoditystockrepository = iiccommoditystockrepository;
            base.CurrentRepository = iiccommoditystockrepository;
        }
    }
}
