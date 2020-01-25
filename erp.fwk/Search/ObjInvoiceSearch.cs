using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp.fwk.Search
{
    public class ObjInvoiceSearch
    {
        public string Client_Title { get; set; }
        public string InvoiceRef { get; set; }
        public int Payment_type { get; set; }
        public int Status { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}
