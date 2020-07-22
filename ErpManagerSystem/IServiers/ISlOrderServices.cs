using Model.Entitys;
using System.Threading.Tasks;
using Common.Help;
using Model.Params;

namespace IServices
{
    public interface ISlOrderServices : IBaseServices<SlOrder>
    {
        Task<PagedList<SlOrder>> GetOrderPaged(SlOrderParams slOrderParams);
    }
}
