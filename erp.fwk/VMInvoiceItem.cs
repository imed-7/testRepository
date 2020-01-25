using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp.fwk
{
    public class VMInvoiceItem
    {
        public string Reference { set; get; }
        public int Quantity { set; get; }
        public Nullable<double> UnitPrice { set; get; }
        public string Title { set; get; }
        public double TVA { set; get; }
        public Nullable<double> TotalPrice { set; get; }
    }
}
