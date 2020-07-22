using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dtos.EditDto
{
    public class AcRolePermissionEditDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
