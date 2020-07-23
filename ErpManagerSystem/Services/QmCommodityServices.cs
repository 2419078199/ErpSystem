using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class QmCommodityServices : BaseServices<QmCommodity>, IQmCommodityServices
    {
        private readonly IQmCommodityRepository _qmcommodityrepository;

        public QmCommodityServices(IQmCommodityRepository qmcommodityrepository)
        {
            _qmcommodityrepository = qmcommodityrepository;
            base.CurrentRepository = qmcommodityrepository;
        }

        public async Task<PagedList<QmCommodity>> QmCommodityPaged(QmCommodityParams qmCommodityParams)
        {
            IQueryable<QmCommodity> pusupplierinfo = _qmcommodityrepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(qmCommodityParams.No))
            {
                pusupplierinfo = pusupplierinfo.Where(a => a.No.Contains(qmCommodityParams.No));
            }
            return await PagedList<QmCommodity>.CreatePagedList(pusupplierinfo, qmCommodityParams.PageSize, qmCommodityParams.PageNum);
        }
    }
}