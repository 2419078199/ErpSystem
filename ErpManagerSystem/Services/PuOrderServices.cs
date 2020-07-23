using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class PuOrderServices : BaseServices<PuOrder>, IPuOrderServices
    {
        private readonly IPuOrderRepository _puorderrepository;

        public PuOrderServices(IPuOrderRepository puorderrepository)
        {
            _puorderrepository = puorderrepository;
            base.CurrentRepository = puorderrepository;
        }

        public async Task<PagedList<PuOrder>> PuOrderPaged(PuOrderParams puOrderParams)
        {
            IQueryable<PuOrder> pusupplierinfo = _puorderrepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(puOrderParams.No))
            {
                pusupplierinfo = pusupplierinfo.Where(a => a.No.Contains(puOrderParams.No));
            }
            return await PagedList<PuOrder>.CreatePagedList(pusupplierinfo, puOrderParams.PageSize, puOrderParams.PageNum);
        }
    }
}