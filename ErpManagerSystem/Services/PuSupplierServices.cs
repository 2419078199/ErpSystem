using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PuSupplierServices : BaseServices<PuSupplier>, IPuSupplierServices
    {
        private readonly IPuSupplierRepository _pusupplierrepository;

        public PuSupplierServices(IPuSupplierRepository pusupplierrepository)
        {
            _pusupplierrepository = pusupplierrepository;
            base.CurrentRepository = pusupplierrepository;
        }


        public async Task<PagedList<PuSupplier>> PuSupplierPaged(PuSupplierParams puSupplierParams)
        {
            IQueryable<PuSupplier> pusupplierinfo = _pusupplierrepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(puSupplierParams.Address))
            {
                pusupplierinfo = pusupplierinfo.Where(a => a.Address.Contains(puSupplierParams.Address));
            }
            return await PagedList<PuSupplier>.CreatePagedList(pusupplierinfo, puSupplierParams.PageSize, puSupplierParams.PageNum);
        }
    }
}
