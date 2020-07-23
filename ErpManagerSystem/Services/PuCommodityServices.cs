using Common.Help;
using IRepository;
using IServices;
using Model.Entitys;
using Model.Params;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class PuCommodityServices : BaseServices<PuCommodity>, IPuCommodityServices
    {
        private readonly IPuCommodityRepository _pucommodityrepository;

        public PuCommodityServices(IPuCommodityRepository pucommodityrepository)
        {
            _pucommodityrepository = pucommodityrepository;
            base.CurrentRepository = pucommodityrepository;
        }

        public async Task<PagedList<PuCommodity>> PuCommodityInfoPaged(PuCommodityParams puCommodityparams)
        {
            IQueryable<PuCommodity> pucommodityinfo = _pucommodityrepository.GetEntitys();
            if (!string.IsNullOrWhiteSpace(puCommodityparams.Name))
            {
                pucommodityinfo = pucommodityinfo.Where(a => a.Name.Contains(puCommodityparams.Name));
            }
            return await PagedList<PuCommodity>.CreatePagedList(pucommodityinfo, puCommodityparams.PageSize, puCommodityparams.PageNum);
        }
    }
}