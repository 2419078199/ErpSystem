using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IIcCommodityRecordServices : IBaseServices<IcCommodityRecord>
    {
        /// <summary>
        /// 原材料审批外键表分页
        /// </summary>
        /// <param name="icCommodityRecordParams"></param>
        /// <returns></returns>
        Task<PagedList<IcCommodityRecord>> IcCommodityRecordPaged(IcCommodityRecordParams icCommodityRecordParams);
    }
}
