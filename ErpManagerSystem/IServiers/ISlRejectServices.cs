using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface ISlRejectServices : IBaseServices<SlReject>
    {
        Task<PagedList<SlReject>> GetRejectPaged(RejectParams rejectParams);
    }
}