using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class SlRejectServices : BaseServices<SlReject>, ISlRejectServices
    {
        private readonly ISlRejectRepository _slrejectrepository;

        public SlRejectServices(ISlRejectRepository slrejectrepository)
        {
            _slrejectrepository = slrejectrepository;
            base.CurrentRepository = slrejectrepository;
        }

        public async Task<PagedList<SlReject>> GetRejectPaged(RejectParams rejectParams)
        {
            IQueryable<SlReject> itemRejects = _slrejectrepository.GetEntitys();
            return await PagedList<SlReject>.CreatePagedList(itemRejects, rejectParams.PageSize, rejectParams.PageNum);
        }
    }
}