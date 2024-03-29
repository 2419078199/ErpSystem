﻿using System;

namespace Model.Dtos.Dto
{
    public class SlSaleOrderDto
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? Nums { get; set; }
        public decimal? Amount { get; set; }
        public string AmountWay { get; set; }
        public decimal? AmountReceivable { get; set; }
        public decimal? AmountReceived { get; set; }
        public int? HandleId { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperatorTime { get; set; }
        public int? AuditStatus { get; set; }
        public int? OrderStatus { get; set; }
        public string Remark { get; set; }
    }
}