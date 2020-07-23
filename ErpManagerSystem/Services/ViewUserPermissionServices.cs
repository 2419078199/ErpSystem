using IRepository;
using IServices;
using Model.Entitys;

namespace Services
{
    public class ViewUserPermissionServices : BaseServices<ViewUserPermission>, IViewUserPermissionServices
    {
        private readonly IViewUserPermissionRepository _viewuserpermissionrepository;

        public ViewUserPermissionServices(IViewUserPermissionRepository viewuserpermissionrepository)
        {
            _viewuserpermissionrepository = viewuserpermissionrepository;
            base.CurrentRepository = viewuserpermissionrepository;
        }
    }
}