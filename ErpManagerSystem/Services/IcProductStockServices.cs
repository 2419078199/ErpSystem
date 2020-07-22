using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class IcProductStockServices : BaseServices<IcProductStock>, IIcProductStockServices
    {
        private readonly IIcProductStockRepository _iicproductstockrepository;

        public IcProductStockServices(IIcProductStockRepository iicproductstockrepository)
        {
            _iicproductstockrepository = iicproductstockrepository;
            base.CurrentRepository = iicproductstockrepository;
        }
    }
}
