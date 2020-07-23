using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos.Dto
{
    public class AcStaffDto
    {
        public int Id { get; set; }
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
