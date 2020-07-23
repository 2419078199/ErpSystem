namespace Model.Dtos.AddDto
{
    public class IcCommodityStockAddDto
    {
        public int? WarehouseId { get; set; }
        public int? CommodityId { get; set; }
        public decimal? Stock { get; set; }
        public string Remark { get; set; }
    }
}