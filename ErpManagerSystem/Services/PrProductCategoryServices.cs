using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PrProductCategoryServices : BaseServices<PrProductCategory>, IPrProductCategoryServices
    {
        private readonly IPrProductCategoryRepository _prproductcategoryrepository;

        public PrProductCategoryServices(IPrProductCategoryRepository prproductcategoryrepository)
        {
            _prproductcategoryrepository = prproductcategoryrepository;
            base.CurrentRepository = prproductcategoryrepository;
        }
    }
}
