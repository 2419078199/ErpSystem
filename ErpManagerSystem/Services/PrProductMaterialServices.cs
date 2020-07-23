using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

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

        public async Task<PagedList<PrProductMaterial>> GetPrProductMaterialPaged(PrProductMaterialParams prProductMaterialParams)
        {
            var prProductMaterials = _prproductmaterialrepository.GetEntitys();
            //auRecords = auRecords.Where(a => a.CategoryId == prProductParams.CategoryId && a.Name.Contains(prProductParams.Name));
            return await PagedList<PrProductMaterial>.CreatePagedList(prProductMaterials, prProductMaterialParams.PageSize, prProductMaterialParams.PageNum);
        }
    }
}