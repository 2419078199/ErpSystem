using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IPuCommodityCategoryServices : IBaseServices<PuCommodityCategory>
    {
        /// <summary>
        /// 产品类别分页
        /// </summary>
        /// <param name="puCommodityCategoryParams"></param>
        /// <returns></returns>
        Task<PagedList<PuCommodityCategory>> PuCommodityCategoryPaged(PuCommodityCategoryParams PuCommodityCategoryParams);
    }
}
