using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class IcCommodityStockServices : BaseServices<IcCommodityStock>, IIcCommodityStockServices
    {
        private readonly IIcCommodityStockRepository _iiccommoditystockrepository;

        public IcCommodityStockServices(IIcCommodityStockRepository iiccommoditystockrepository)
        {
            _iiccommoditystockrepository = iiccommoditystockrepository;
            base.CurrentRepository = iiccommoditystockrepository;
        }

        public async Task<PagedList<IcCommodityStock>> IcCommodityStockPaged(IcCommodityStockParams icCommodityStockParams)
        {
            IQueryable<IcCommodityStock> pusupplierinfo = _iiccommoditystockrepository.GetEntitys();
            if (icCommodityStockParams.WarehouseId != 0)
            {
                pusupplierinfo = pusupplierinfo.Where(a => a.WarehouseId == icCommodityStockParams.WarehouseId);
            }
            return await PagedList<IcCommodityStock>.CreatePagedList(pusupplierinfo, icCommodityStockParams.PageSize, icCommodityStockParams.PageNum);
        }
    }
}