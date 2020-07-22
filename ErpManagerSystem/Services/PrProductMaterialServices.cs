using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PrProductMaterialServices : BaseServices<PrProductMaterial>, IPrProductMaterialServices
    {
        private readonly IPrProductMaterialRepository _prproductmaterialrepository;

        public PrProductMaterialServices(IPrProductMaterialRepository prproductmaterialrepository)
        {
            _prproductmaterialrepository = prproductmaterialrepository;
            base.CurrentRepository = prproductmaterialrepository;
        }
    }
}
