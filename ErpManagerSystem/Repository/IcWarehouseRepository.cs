using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class IcWarehouseRepository : BaseRepository<IcWarehouse>, IIcWarehouseRepository
    {
        public IcWarehouseRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
