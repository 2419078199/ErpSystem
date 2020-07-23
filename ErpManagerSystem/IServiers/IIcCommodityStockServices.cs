using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface IIcCommodityStockServices : IBaseServices<IcCommodityStock>
    {
        /// <summary>
        /// 原材料仓库外键表分页
        /// </summary>
        /// <param name="icCommodityStockParams"></param>
        /// <returns></returns>
        Task<PagedList<IcCommodityStock>> IcCommodityStockPaged(IcCommodityStockParams icCommodityStockParams);
    }
}