namespace Model.Dtos.AddDto
{
    public class AcStaffAddDto
    {
        public string Name { get; set; }
        public bool Sex { get; set; }
        public string No { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public int? DepartmentId { get; set; }
        public bool Status { get; set; }
        public int? UserId { get; set; }
        public string Remark { get; set; }
    }
}