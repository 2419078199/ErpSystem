using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface IPrProductServices : IBaseServices<PrProduct>
    {
        Task<PagedList<PrProduct>> GetPrProductPaged(PrProductParams prProductParams);
    }
}