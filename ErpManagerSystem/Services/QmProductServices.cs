using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<PagedList<QmProduct>> GetQmProductPaged(QmProductParams qmProductParams)
        {
            var qmProducts = _qmproductrepository.GetEntitys();
            //auRecords = auRecords.Where(a => a.CategoryId == prProductParams.CategoryId && a.Name.Contains(prProductParams.Name));
            return await PagedList<QmProduct>.CreatePagedList(qmProducts, qmProductParams.PageSize, qmProductParams.PageNum);
        }
    }
}
