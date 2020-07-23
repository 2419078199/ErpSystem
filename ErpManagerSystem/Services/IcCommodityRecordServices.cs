using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public async Task<PagedList<IcCommodityRecord>> IcCommodityRecordPaged(IcCommodityRecordParams icCommodityRecord)
        {
            IQueryable<IcCommodityRecord> pusupplierinfo = _iccommodityrecordrepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(icCommodityRecord.Name))
            {
                pusupplierinfo = pusupplierinfo.Where(a => a.Name.Contains(icCommodityRecord.Name));
            }
            return await PagedList<IcCommodityRecord>.CreatePagedList(pusupplierinfo, icCommodityRecord.PageSize, icCommodityRecord.PageNum);
        }
    }
}
