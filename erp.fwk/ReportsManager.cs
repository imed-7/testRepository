using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
using erp.fwk.VM;
namespace erp.fwk
{
   public class ReportsManager
    {
        public static List<VME> GetBusinessNumber(string strDate)
        {
            DateTime date = Convert.ToDateTime(strDate);
            List<VME> BusinessList = new List<VME>();
            for (int i = 1; i < 12; i++)
            {
              DateTime  dateIn = date.AddDays(30* (i - 1));
                DateTime dateout = date.AddDays(30 * (i));

                erp_dataEntities2 db = new erp_dataEntities2();
                var BN = (from n in db.Invoices
                           
                            
                            where (n.CreationDate >= dateIn)
                            where (n.CreationDate <dateout)
                           
                            select new
                            {
                               BusinessNumber = n.TotalPrice
                               
                            }).Sum(x=>x.BusinessNumber);

                decimal decBusinessNumber = 0;
                    if (BN != null)
                    {
                        decBusinessNumber = Convert.ToDecimal(BN);
                    }
                    VME vme = new VM.VME()
                    {
                        BusinessNumber = decBusinessNumber
                  
                     
                       
                    };
                    BusinessList.Add(vme);
                }
            

            return BusinessList;
        }
    }
}
