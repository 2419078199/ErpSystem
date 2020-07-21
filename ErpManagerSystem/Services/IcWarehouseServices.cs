using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class IcWarehouseServices : BaseServices<IcWarehouse>, IIcWarehouseServices
    {
        private readonly IIcWarehouseRepository _icwarehouserepository;

        public IcWarehouseServices(IIcWarehouseRepository icwarehouserepository)
        {
            _icwarehouserepository = icwarehouserepository;
            base.CurrentRepository = icwarehouserepository;
        }

        public async Task<PagedList<IcWarehouse>> GetIcWarehousePaged(IcWarehouseParams icWarehouseParams)
        {
            var icWarehouses = _icwarehouserepository.GetEntitys();
            //icWarehouses = icWarehouses.Where();
            return await PagedList<IcWarehouse>.CreatePagedList(icWarehouses, icWarehouseParams.PageSize, icWarehouseParams.PageNum);
        }
    }
}
