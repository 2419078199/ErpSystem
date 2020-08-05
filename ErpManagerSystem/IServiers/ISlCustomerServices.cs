using Common.Help;
using Model.Entitys;
using Model.Params;
using System.Threading.Tasks;

namespace IServices
{
    public interface ISlCustomerServices : IBaseServices<SlCustomer>
    {
        Task<PagedList<SlCustomer>> GetCustomerPaged(CustomerParams customerParams);
    }
}