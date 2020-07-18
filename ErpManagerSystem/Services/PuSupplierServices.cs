using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
