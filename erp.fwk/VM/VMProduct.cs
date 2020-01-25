using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace erp.fwk.VM
{
   public class VMProduct
    {
        public string Title { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<decimal> IdCurrency { get; set; }
        public decimal MargeReduction { get; set; }
        public string Code { get; set; }
        public int Id { get; set; }
        public int state_dispo { get; set; }
        public Nullable<int> State { get; set; }

        public static VMProduct GetVMProduct(Product P)
        {
            if(P.IdCategory != null && P.IdSupplier != null)
            {
                erp_dataEntities2 db = new erp_dataEntities2();
                VMProduct VMP = new VMProduct();
                decimal decId = Convert.ToDecimal(P.IdCategory);
                VMP.Category = db.Categories.Where(x => x.Id == decId).FirstOrDefault().Title;
                VMP.Supplier = db.Suppliers.Where(x => x.Id == P.IdSupplier).FirstOrDefault().Title;
                VMP.LastUpdateDate = P.LastUpdateDate;
                VMP.Price = P.Price;
                VMP.Title = P.Title;
                VMP.Code = P.Code;
                VMP.Id = P.Id;
                VMP.Amount = P.Amount;
                VMP.State = P.State;
                return VMP;
            }
            
            return null;
        }
    }
}
