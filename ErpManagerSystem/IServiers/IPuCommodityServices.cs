using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IPuCommodityServices : IBaseServices<PuCommodity>
    {
        /// <summary>
        /// 原材料分页
        /// </summary>
        /// <param name="puCommodityparams"></param>
        /// <returns></returns>
        Task<PagedList<PuCommodity>> PuCommodityInfoPaged(PuCommodityParams puCommodityparams);
    }
}
