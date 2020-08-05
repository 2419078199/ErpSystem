using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class SlCustomerServices : BaseServices<SlCustomer>, ISlCustomerServices
    {
        private readonly ISlCustomerRepository _slcustomerrepository;

        public SlCustomerServices(ISlCustomerRepository slcustomerrepository)
        {
            _slcustomerrepository = slcustomerrepository;
            base.CurrentRepository = slcustomerrepository;
        }
        public async Task<PagedList<SlCustomer>> GetCustomerPaged(CustomerParams customerParams)
        {
            var items = _slcustomerrepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(customerParams.CustomerName))
            {
                items = items.Where(a => a.Name.Contains(customerParams.CustomerName));
            }
            return await PagedList<SlCustomer>.CreatePagedList(items, customerParams.PageSize, customerParams.PageNum);
        }
    }
}