using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class IcProductRecordServices : BaseServices<IcProductRecord>, IIcProductRecordServices
    {
        private readonly IIcProductRecordRepository _icproductrecordrepository;

        public IcProductRecordServices(IIcProductRecordRepository icproductrecordrepository)
        {
            _icproductrecordrepository = icproductrecordrepository;
            base.CurrentRepository = icproductrecordrepository;
        }
    }
}
