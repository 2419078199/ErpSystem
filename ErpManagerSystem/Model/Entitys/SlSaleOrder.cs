﻿using System;
using System.Collections.Generic;

namespace Model.Entitys
{
    public partial class SlSaleOrder
    {
        public SlSaleOrder()
        {
            SlReject = new HashSet<SlReject>();
        }

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

        public virtual SlCustomer Customer { get; set; }
        public virtual AcStaff Handle { get; set; }
        public virtual AcStaff Operator { get; set; }
        public virtual SlOrder Order { get; set; }
        public virtual PrProduct Product { get; set; }
        public virtual ICollection<SlReject> SlReject { get; set; }
    }
}