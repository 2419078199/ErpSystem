using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace Services
{
    public class IcProductStockServices : BaseServices<IcProductStock>, IIcProductStockServices
    {
        private readonly IIcProductStockRepository _iicproductstockrepository;

        public IcProductStockServices(IIcProductStockRepository iicproductstockrepository)
        {
            _iicproductstockrepository = iicproductstockrepository;
            base.CurrentRepository = iicproductstockrepository;
        }

        public async Task<PagedList<IcProductStock>> GetIcProductStockPaged(IcProductStockParams icProductStockParams)
        {
            var icProductStocks = _iicproductstockrepository.GetEntitys();
            //icWarehouses = icWarehouses.Where();
            return await PagedList<IcProductStock>.CreatePagedList(icProductStocks, icProductStockParams.PageSize, icProductStockParams.PageNum);
        }
    }
}