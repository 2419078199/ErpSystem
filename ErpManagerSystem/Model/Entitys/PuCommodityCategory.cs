﻿using System.Collections.Generic;

namespace Model.Entitys
{
    public partial class PuCommodityCategory
    {
        public PuCommodityCategory()
        {
            PuCommodity = new HashSet<PuCommodity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<PuCommodity> PuCommodity { get; set; }
    }
}