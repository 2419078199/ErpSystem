using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IIcProductStockServices : IBaseServices<IcProductStock>
    {
        Task<PagedList<IcProductStock>> GetIcProductStockPaged(IcProductStockParams icProductStockParams);
    }
}
