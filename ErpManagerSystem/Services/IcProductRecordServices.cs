using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace Services
{
    public class IcProductRecordServices : BaseServices<IcProductRecord>, IIcProductRecordServices
    {
        private readonly IIcProductRecordRepository _icproductrecordrepository;

        public IcProductRecordServices(IIcProductRecordRepository icproductrecordrepository)
        {
            _icproductrecordrepository = icproductrecordrepository;
            base.CurrentRepository = icproductrecordrepository;
        }

        public async Task<PagedList<IcProductRecord>> GetIcProductRecordPaged(IcProductRecordParams icProductRecordParams)
        {
            var icProductRecords = _icproductrecordrepository.GetEntitys();
            //auRecords = auRecords.Where(a => a.CategoryId == prProductParams.CategoryId && a.Name.Contains(prProductParams.Name));
            return await PagedList<IcProductRecord>.CreatePagedList(icProductRecords, icProductRecordParams.PageSize, icProductRecordParams.PageNum);
        }
    }
}