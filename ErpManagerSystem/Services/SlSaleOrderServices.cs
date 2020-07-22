using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class SlSaleOrderServices : BaseServices<SlSaleOrder>, ISlSaleOrderServices
    {
        private readonly ISlSaleOrderRepository _slsaleorderrepository;

        public SlSaleOrderServices(ISlSaleOrderRepository slsaleorderrepository)
        {
            _slsaleorderrepository = slsaleorderrepository;
            base.CurrentRepository = slsaleorderrepository;
        }
    }
}
