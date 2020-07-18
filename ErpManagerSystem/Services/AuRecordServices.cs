using IRepository;
using IServices;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AuRecordServices : BaseServices<AuRecord>, IAuRecordServices
    {
        private readonly IAuRecordRepository _aurecordservicesrepository;

        public AuRecordServices(IAuRecordRepository aurecordservicesrepository)
        {
            _aurecordservicesrepository = aurecordservicesrepository;
            base.CurrentRepository = aurecordservicesrepository;
        }
    }
}
