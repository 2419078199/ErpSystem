using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos.EditDto
{
    public class IcCommodityStockEditDto
    {
        public int Id { get; set; }
        public int? WarehouseId { get; set; }
        public int? CommodityId { get; set; }
        public decimal? Stock { get; set; }
        public string Remark { get; set; }
    }
}
