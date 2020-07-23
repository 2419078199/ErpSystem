using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface ISlSaleOrderServices : IBaseServices<SlSaleOrder>
    {
        Task<PagedList<SlSaleOrder>> GetSaleOrderPaged(SlSaleOrderParams slSaleOrderParams);
    }
}