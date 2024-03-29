﻿using System;

namespace Model.Dtos.AddDto
{
    public class SlCustomerAddDto
    {
        public string Name { get; set; }
        public string Postcode { get; set; }
        public string Address { get; set; }
        public string Custtel { get; set; }
        public string Linkman { get; set; }
        public string Linktel { get; set; }
        public string Email { get; set; }
        public bool? Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string Love { get; set; }
        public string Remark { get; set; }
    }
}