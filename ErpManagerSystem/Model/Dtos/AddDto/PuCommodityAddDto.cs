using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos.AddDto
{
    public class PuCommodityAddDto
    {
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Stock { get; set; }
        public string Place { get; set; }
        public string Spec { get; set; }
        public string LicenseNo { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public string Remark { get; set; }
    }
}
