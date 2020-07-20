﻿using System;
using System.Collections.Generic;

namespace Model.Entitys
{
    public partial class AcDepartment
    {
        public AcDepartment()
        {
            AcStaff = new HashSet<AcStaff>();
            IcCommodityRecord = new HashSet<IcCommodityRecord>();
            PrProductMaterial = new HashSet<PrProductMaterial>();
            PrProductTask = new HashSet<PrProductTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<AcStaff> AcStaff { get; set; }
        public virtual ICollection<IcCommodityRecord> IcCommodityRecord { get; set; }
        public virtual ICollection<PrProductMaterial> PrProductMaterial { get; set; }
        public virtual ICollection<PrProductTask> PrProductTask { get; set; }
    }
}