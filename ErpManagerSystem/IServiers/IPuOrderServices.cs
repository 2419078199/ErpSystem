using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IPuOrderServices : IBaseServices<PuOrder>
    {
        /// <summary>
        /// 订单表分页
        /// </summary>
        /// <param name="puOrderParams"></param>
        /// <returns></returns>
        Task<PagedList<PuOrder>> PuOrderPaged(PuOrderParams puOrderParams);
    }
}
