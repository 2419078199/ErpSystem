namespace Model.Dtos.Dto
{
    public class PuCommodityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Stock { get; set; }
        public string Place { get; set; }
        public string Spec { get; set; }
        public string LicenseNo { get; set; }
        public string Remark { get; set; }
    }
}