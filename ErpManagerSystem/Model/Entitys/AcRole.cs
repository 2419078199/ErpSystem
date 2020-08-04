using System;
using System.Collections.Generic;

namespace Model.Entitys
{
    public partial class AcRole
    {
        public AcRole()
        {
            AcRolePermission = new HashSet<AcRolePermission>();
            AcUserInfo = new HashSet<AcUserInfo>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<AcRolePermission> AcRolePermission { get; set; }
        public virtual ICollection<AcUserInfo> AcUserInfo { get; set; }

        public static implicit operator AcRole(AcUserInfo v)
        {
            throw new NotImplementedException();
        }
    }
}