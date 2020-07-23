using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Params
{
    public class IcCommodityStockParams : BaseParams
    {
        public int? WarehouseId { get; set; }
        public int? CommodityId { get; set; }
    }
}
