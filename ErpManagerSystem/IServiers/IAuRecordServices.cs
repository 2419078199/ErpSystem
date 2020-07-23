using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAuRecordServices : IBaseServices<AuRecord>
    {
        Task<PagedList<AuRecord>> GetAuRecordPaged(AuRecordParams auRecordParams);
    }
}