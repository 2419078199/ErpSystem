using System;
using System.Collections.Generic;
using System.Text;
using IRepository;
using Model.Entitys;

namespace Repository
{
    public class PuSupplierRepository : BaseRepository<PuSupplier>, IPuSupplierRepository
    {
        public PuSupplierRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
