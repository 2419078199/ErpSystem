using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class SlOrderServices : BaseServices<SlOrder>, ISlOrderServices
    {
        private readonly ISlOrderRepository _slorderrepository;

        public SlOrderServices(ISlOrderRepository slorderrepository)
        {
            _slorderrepository = slorderrepository;
            base.CurrentRepository = slorderrepository;
        }
    }
}
