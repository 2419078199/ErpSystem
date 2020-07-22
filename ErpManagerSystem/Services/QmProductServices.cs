using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class QmProductServices : BaseServices<QmProduct>, IQmProductServices
    {
        private readonly IQmProductRepository _qmproductrepository;

        public QmProductServices(IQmProductRepository qmproductrepository)
        {
            _qmproductrepository = qmproductrepository;
            base.CurrentRepository = qmproductrepository;
        }
    }
}
