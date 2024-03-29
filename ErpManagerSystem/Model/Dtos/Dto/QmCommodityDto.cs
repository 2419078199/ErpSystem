﻿using System;

namespace Model.Dtos.Dto
{
    public class QmCommodityDto
    {
        public string No { get; set; }
        public int? OrderId { get; set; }
        public DateTime? QmDate { get; set; }
        public int? Result { get; set; }
        public int? HandleId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public string Pic { get; set; }
        public string Remark { get; set; }
    }
}