using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
