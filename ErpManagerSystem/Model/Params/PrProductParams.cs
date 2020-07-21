using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Params
{
    public class PrProductParams:BaseParams
    {
        public int? CategoryId { get; set; } = 0;
        public string Name { get; set; } = "";
    }
}
