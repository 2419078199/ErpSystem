using System;
using System.Collections.Generic;

namespace Model.Entitys
{
    public partial class IcCommodityStock
    {
        public int Id { get; set; }
        public int? WarehouseId { get; set; }
        public int? CommodityId { get; set; }
        public decimal? Stock { get; set; }
        public string Remark { get; set; }

        public virtual PuCommodity Commodity { get; set; }
        public virtual IcWarehouse Warehouse { get; set; }
    }
}
