using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos.Dto
{
     public class IcCommodityStockDto
    {
        public int? WarehouseId { get; set; }
        public int? CommodityId { get; set; }
        public decimal? Stock { get; set; }
        public string Remark { get; set; }
    }
}
