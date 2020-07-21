using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IIcWarehouseServices : IBaseServices<IcWarehouse>
    {
        Task<PagedList<IcWarehouse>> GetIcWarehousePaged(IcWarehouseParams icWarehouseParams);
    }
}
