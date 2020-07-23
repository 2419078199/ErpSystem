using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface IPrProductMaterialServices : IBaseServices<PrProductMaterial>
    {
        Task<PagedList<PrProductMaterial>> GetPrProductMaterialPaged(PrProductMaterialParams prProductMaterialParams);
    }
}