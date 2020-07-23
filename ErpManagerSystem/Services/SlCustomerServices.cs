using IRepository;
using IServices;
using Model.Entitys;

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
    }
}