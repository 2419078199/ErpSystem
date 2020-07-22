using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
