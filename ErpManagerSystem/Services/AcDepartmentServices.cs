using IRepository;
using IServices;
using Model.Entitys;

namespace Services
{
    public class AcDepartmentServices : BaseServices<AcDepartment>, IAcDepartmentServices
    {
        private readonly IAcDepartmentRepository _acdepartmentrepository;

        public AcDepartmentServices(IAcDepartmentRepository acdepartmentrepository)
        {
            _acdepartmentrepository = acdepartmentrepository;
            base.CurrentRepository = acdepartmentrepository;
        }
    }
}