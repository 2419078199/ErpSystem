using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos.AddDto
{
    public class IcProductRecordAddDto
    {
        public string Name { get; set; }
        public bool? IsIn { get; set; }
        public int? SourceCategory { get; set; }
        public int? SourceId { get; set; }
        public string SourceNo { get; set; }
        public int? ProductId { get; set; }
        public string Batch { get; set; }
        public decimal? Nums { get; set; }
        public string Reason { get; set; }
        public int? DepartmentId { get; set; }
        public int? StaffId { get; set; }
        public int? WarehouseId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
    }
}
