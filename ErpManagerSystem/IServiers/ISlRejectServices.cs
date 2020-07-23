using Model.Entitys;
using System.Threading.Tasks;
using Common.Help;
using Model.Params;

namespace IServices
{
    public interface ISlRejectServices : IBaseServices<SlReject>
    {
        Task<PagedList<SlReject>> GetRejectPaged(RejectParams rejectParams);
    }
}
