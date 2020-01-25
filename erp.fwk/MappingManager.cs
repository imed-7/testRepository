using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using erp.fwk.VM;
using DataSource;
namespace erp.fwk
{
    public class MappingManager
    {

        public static  Invoice GetDevisModel(VMInvoice VMI)
        {
            Invoice I = new Invoice()
            {
                Id = VMI.Id,
                IdClient = VMI.IdClient,
                CreationDate = VMI.CreationDate,
                TotalPrice = VMI.TotalPrice,
                TotalPriceHT = VMI.TotalPriceHT,
                TotalTVA = VMI.TotalTVA,
                type = VMI.type,
                ExpirationDate = VMI.ExpirationDate
            };

            return I;
            
        }
    }
}
