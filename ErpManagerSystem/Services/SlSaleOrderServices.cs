using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class SlSaleOrderServices : BaseServices<SlSaleOrder>, ISlSaleOrderServices
    {
        private readonly ISlSaleOrderRepository _slsaleorderrepository;

        public SlSaleOrderServices(ISlSaleOrderRepository slsaleorderrepository)
        {
            _slsaleorderrepository = slsaleorderrepository;
            base.CurrentRepository = slsaleorderrepository;
        }

        public async Task<PagedList<SlSaleOrder>> GetSaleOrderPaged(SlSaleOrderParams slSaleOrderParams)
        {
            IQueryable<SlSaleOrder> itemOrders = _slsaleorderrepository.GetEntitys();
            return await PagedList<SlSaleOrder>.CreatePagedList(itemOrders, slSaleOrderParams.PageSize, slSaleOrderParams.PageNum);
        }
    }
}