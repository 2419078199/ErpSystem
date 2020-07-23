using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface IQmProductServices : IBaseServices<QmProduct>
    {
        Task<PagedList<QmProduct>> GetQmProductPaged(QmProductParams qmProductParams);
    }
}