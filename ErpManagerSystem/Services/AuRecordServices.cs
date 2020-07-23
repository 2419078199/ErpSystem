using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace Services
{
    public class AuRecordServices : BaseServices<AuRecord>, IAuRecordServices
    {
        private readonly IAuRecordRepository _aurecordservicesrepository;

        public AuRecordServices(IAuRecordRepository aurecordservicesrepository)
        {
            _aurecordservicesrepository = aurecordservicesrepository;
            base.CurrentRepository = aurecordservicesrepository;
        }

        public async Task<PagedList<AuRecord>> GetAuRecordPaged(AuRecordParams auRecordParams)
        {
            var auRecords = _aurecordservicesrepository.GetEntitys();
            //auRecords = auRecords.Where(a => a.CategoryId == prProductParams.CategoryId && a.Name.Contains(prProductParams.Name));
            return await PagedList<AuRecord>.CreatePagedList(auRecords, auRecordParams.PageSize, auRecordParams.PageNum);
        }
    }
}