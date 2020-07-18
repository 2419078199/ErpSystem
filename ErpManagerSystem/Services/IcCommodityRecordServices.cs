using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class IcCommodityRecordServices : BaseServices<IcCommodityRecord>, IIcCommodityRecordServices
    {
        private readonly IIcCommodityRecordRepository _iccommodityrecordrepository;
        public IcCommodityRecordServices(IIcCommodityRecordRepository iccommodityrecordrepository)
        {
            _iccommodityrecordrepository = iccommodityrecordrepository;
            base.CurrentRepository = iccommodityrecordrepository;
        }
    }
}
