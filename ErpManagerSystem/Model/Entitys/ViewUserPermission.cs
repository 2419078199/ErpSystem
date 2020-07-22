using System;
using System.Collections.Generic;

namespace Model.Entitys
{
    public partial class ViewUserPermission
    {
        public int Userid { get; set; }
        public int? RoleId { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? Pid { get; set; }
        public bool? IsMenu { get; set; }
        public string Icon { get; set; }
    }
}
