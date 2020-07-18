using IRepository;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AuRecordRepository : BaseRepository<AuRecord>, IAuRecordRepository
    {
        public AuRecordRepository(DB_ERPContext dbErpContext) : base(dbErpContext)
        {
        }
    }
}
