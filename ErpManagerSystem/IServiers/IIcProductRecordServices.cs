using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface IIcProductRecordServices : IBaseServices<IcProductRecord>
    {
        Task<PagedList<IcProductRecord>> GetIcProductRecordPaged(IcProductRecordParams icProductRecordParams);
    }
}