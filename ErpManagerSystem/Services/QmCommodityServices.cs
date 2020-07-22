using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class QmCommodityServices : BaseServices<QmCommodity>, IQmCommodityServices
    {
        private readonly IQmCommodityRepository _qmcommodityrepository;

        public QmCommodityServices(IQmCommodityRepository qmcommodityrepository)
        {
            _qmcommodityrepository = qmcommodityrepository;
            base.CurrentRepository = qmcommodityrepository;
        }
    }
}
