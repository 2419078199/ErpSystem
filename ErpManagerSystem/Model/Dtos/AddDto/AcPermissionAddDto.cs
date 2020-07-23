using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos.AddDto
{
    public class AcPermissionAddDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int? Pid { get; set; }
        public bool? IsMenu { get; set; }
        public string Icon { get; set; }
        public string Remark { get; set; }
    }
}
