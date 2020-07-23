using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
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
        public async Task<PagedList<AuRecord>> GetRecordPaged(AuRecordParams auRecordParams)
        {
            IQueryable<AuRecord> itemRecords = _aurecordservicesrepository.GetEntitys();
            return await PagedList<AuRecord>.CreatePagedList(itemRecords, auRecordParams.PageSize, auRecordParams.PageNum);
        }
    }
}
