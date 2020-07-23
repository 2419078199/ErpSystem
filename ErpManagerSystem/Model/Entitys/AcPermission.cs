using System.Collections.Generic;

namespace Model.Entitys
{
    public partial class AcPermission
    {
        public AcPermission()
        {
            AcRolePermission = new HashSet<AcRolePermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? Pid { get; set; }
        public bool? IsMenu { get; set; }
        public string Icon { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<AcRolePermission> AcRolePermission { get; set; }
    }
}