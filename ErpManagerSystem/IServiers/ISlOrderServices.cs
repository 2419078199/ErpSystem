using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface ISlOrderServices : IBaseServices<SlOrder>
    {
        Task<PagedList<SlOrder>> GetOrderPaged(SlOrderParams slOrderParams);
    }
}