﻿using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface IIcWarehouseServices : IBaseServices<IcWarehouse>
    {
        Task<PagedList<IcWarehouse>> GetIcWarehousePaged(IcWarehouseParams icWarehouseParams);
    }
}