namespace Model.Dtos.Dto
{
    public class IcProductStockDto
    {
        public int Id { get; set; }
        public int? WarehouseId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Stock { get; set; }
        public string Remark { get; set; }
    }
}