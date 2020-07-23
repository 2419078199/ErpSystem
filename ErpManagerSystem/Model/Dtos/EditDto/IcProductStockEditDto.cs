namespace Model.Dtos.EditDto
{
    public class IcProductStockEditDto
    {
        public int Id { get; set; }
        public int? WarehouseId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Stock { get; set; }
        public string Remark { get; set; }
    }
}