using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PrProductTaskServices : BaseServices<PrProductTask>, IPrProductTaskServices
    {
        private readonly IPrProductTaskRepository _iprproducttaskrepository;

        public PrProductTaskServices(IPrProductTaskRepository iprproducttaskrepository)
        {
            _iprproducttaskrepository = iprproducttaskrepository;
            base.CurrentRepository = iprproducttaskrepository;
        }
    }
}
