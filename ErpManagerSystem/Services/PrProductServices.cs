using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PrProductServices : BaseServices<PrProduct>, IPrProductServices
    {
        private readonly IPrProductRepository _prproductrepository;

        public PrProductServices(IPrProductRepository prproductrepository)
        {
            _prproductrepository = prproductrepository;
            base.CurrentRepository = prproductrepository;
        }
    }
}
