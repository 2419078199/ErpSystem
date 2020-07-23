using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class PrProductTaskServices : BaseServices<PrProductTask>, IPrProductTaskServices
    {
        private readonly IPrProductTaskRepository _iprproducttaskrepository;

        public PrProductTaskServices(IPrProductTaskRepository iprproducttaskrepository)
        {
            _iprproducttaskrepository = iprproducttaskrepository;
            base.CurrentRepository = iprproducttaskrepository;
        }

        public async Task<PagedList<PrProductTask>> GetPrProductTaskPaged(PrProductTaskParams prProductTaskParams)
        {
            IQueryable<PrProductTask> prProductTask = _iprproducttaskrepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(prProductTaskParams.SearchInfo))
            {
                prProductTask = prProductTask.Where(a => a.No.Contains(prProductTaskParams.SearchInfo) || a.Batch.Contains(prProductTaskParams.SearchInfo));
            }
            return await PagedList<PrProductTask>.CreatePagedList(prProductTask, prProductTaskParams.PageSize, prProductTaskParams.PageNum);
        }
    }
}