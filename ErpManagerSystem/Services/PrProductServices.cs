using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<PagedList<PrProduct>> GetPrProductPaged(PrProductParams prProductParams)
        {
            var prProducts = _prproductrepository.GetEntitys();
            if (prProductParams.CategoryId !=0)
            {
                prProducts = prProducts.Where(a =>a.CategoryId== prProductParams.CategoryId && a.Name.Contains(prProductParams.Name));
            }
            else
            {
                prProducts = prProducts.Where(a =>a.Name.Contains(prProductParams.Name));
            }
            return await PagedList<PrProduct>.CreatePagedList(prProducts, prProductParams.PageSize, prProductParams.PageNum);
        }
    }
}
