using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PuOrderServices : BaseServices<PuOrder>, IPuOrderServices
    {
        private readonly IPuOrderRepository _puorderrepository;

        public PuOrderServices(IPuOrderRepository puorderrepository)
        {
            _puorderrepository = puorderrepository;
            base.CurrentRepository = puorderrepository;
        }
    }
}
