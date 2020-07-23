namespace Model.Dtos.Dto
{
    public class AcPermissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? Pid { get; set; }
        public bool? IsMenu { get; set; }
        public string Icon { get; set; }
        public string Remark { get; set; }
    }
}