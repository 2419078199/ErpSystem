﻿using System;

namespace Model.Dtos.EditDto
{
    public class PrProductTaskEditDto
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int? ProductId { get; set; }
        public decimal? Nums { get; set; }
        public DateTime? ProductDate { get; set; }
        public string Batch { get; set; }
        public int? DepartmentId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
        public int? QmId { get; set; }
    }
}