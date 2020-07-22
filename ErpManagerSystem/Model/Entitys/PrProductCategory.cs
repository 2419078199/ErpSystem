using System;
using System.Collections.Generic;

namespace Model.Entitys
{
    public partial class PrProductCategory
    {
        public PrProductCategory()
        {
            PrProduct = new HashSet<PrProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<PrProduct> PrProduct { get; set; }
    }
}
