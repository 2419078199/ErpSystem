﻿using System;

namespace Model.Dtos.EditDto
{
    public class IcWarehouseEditDto
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public int? Category { get; set; }
        public string Address { get; set; }
        public int? ManagerId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
    }
}