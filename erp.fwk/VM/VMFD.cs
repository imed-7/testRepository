using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp.fwk.VM
{
   public class VMFD
    {
        public System.DateTime CreationDate { get; set; }
        public Nullable<decimal> TotalPriceHT { get; set; }
   
        public string Client_Title { get; set; }
        public string TotalPrice { get; set; }
        public string Id { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> PaymentType { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }

    }
}
