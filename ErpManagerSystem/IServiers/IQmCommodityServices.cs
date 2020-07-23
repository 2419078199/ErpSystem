using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IQmCommodityServices : IBaseServices<QmCommodity>
    {
        /// <summary>
        /// 原材料质检表分页
        /// </summary>
        /// <param name="qmCommodityParams"></param>
        /// <returns></returns>
        Task<PagedList<QmCommodity>> QmCommodityPaged(QmCommodityParams qmCommodityParams);
    }
}
