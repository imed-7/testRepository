using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp.fwk
{
    public class ProductSearch
    {
        public string key { get; set; }
        public string strCategory { get; set; }
        public string strSupplier { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
