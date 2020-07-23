using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Help;
using Model.Params;

namespace Services
{
    public class SlRejectServices : BaseServices<SlReject>, ISlRejectServices
    {
        private readonly ISlRejectRepository _slrejectrepository;

        public SlRejectServices(ISlRejectRepository slrejectrepository)
        {
            _slrejectrepository = slrejectrepository;
            base.CurrentRepository = slrejectrepository;
        }

        public async Task<PagedList<SlReject>> GetRejectPaged(RejectParams rejectParams)
        {
            IQueryable<SlReject> itemRejects = _slrejectrepository.GetEntitys();
            return await PagedList<SlReject>.CreatePagedList(itemRejects, rejectParams.PageSize, rejectParams.PageNum);
        }
    }
}
