using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class SysConfigItemServices : BaseServices<SysConfigItem>, ISysConfigItemServices
    {
        private readonly ISysConfigItemRepository _sysconfigitemrepository;

        public SysConfigItemServices(ISysConfigItemRepository sysconfigitemrepository)
        {
            _sysconfigitemrepository = sysconfigitemrepository;
            base.CurrentRepository = sysconfigitemrepository;
        }
    }
}
