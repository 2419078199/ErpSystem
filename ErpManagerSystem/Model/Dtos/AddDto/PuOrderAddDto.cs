﻿using System;

namespace Model.Dtos.AddDto
{
    public class PuOrderAddDto
    {
        public string No { get; set; }
        public int? CommodityId { get; set; }
        public decimal? Nums { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Batch { get; set; }
        public decimal? Amount { get; set; }
        public int? AmountWay { get; set; }
        public decimal? AmountReceivable { get; set; }
        public decimal? AmountReceived { get; set; }
        public int? HandleId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? Status { get; set; }
        public int? QmId { get; set; }
        public string Remark { get; set; }
    }
}