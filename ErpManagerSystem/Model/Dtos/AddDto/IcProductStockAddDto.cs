namespace Model.Dtos.AddDto
{
    public class IcProductStockAddDto
    {
        public int? WarehouseId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Stock { get; set; }
        public string Remark { get; set; }
    }
}