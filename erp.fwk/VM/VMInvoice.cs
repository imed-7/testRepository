using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp.fwk.VM
{
    public class VMInvoice
    {
        public System.DateTime CreationDate { get; set; }
        public Nullable<decimal> TotalPriceHT { get; set; }

        public Nullable<decimal> TotalTVA { get; set; }
        [Required(ErrorMessage = "champ obligatoire")]
        public int IdClient { get; set; }

        public Nullable<decimal> TotalPrice { get; set; }
        public int Id { get; set; }

        public Nullable<int> type { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
    }
}
