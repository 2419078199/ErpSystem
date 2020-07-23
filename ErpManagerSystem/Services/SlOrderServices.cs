using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class SlOrderServices : BaseServices<SlOrder>, ISlOrderServices
    {
        private readonly ISlOrderRepository _slorderrepository;

        public SlOrderServices(ISlOrderRepository slorderrepository)
        {
            _slorderrepository = slorderrepository;
            base.CurrentRepository = slorderrepository;
        }

        public async Task<PagedList<SlOrder>> GetOrderPaged(SlOrderParams slOrderParams)
        {
            IQueryable<SlOrder> itemsOrders = _slorderrepository.GetEntitys();
            return await PagedList<SlOrder>.CreatePagedList(itemsOrders, slOrderParams.PageSize, slOrderParams.PageNum);
        }
    }
}