using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Help;
using Model.Params;

namespace IServices
{
    public interface ISlSaleOrderServices : IBaseServices<SlSaleOrder>
    {
        Task<PagedList<SlSaleOrder>> GetSaleOrderPaged(SlSaleOrderParams slSaleOrderParams);
    }
}
