using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
using erp.fwk.VM;
namespace erp.fwk

{
    public class InvoiceManager
    {
        public static void AddInvoice(Invoice invoice, out int RefInvoice)
        {
            RefInvoice = 0;
            erp_dataEntities2 db = new erp_dataEntities2();
            db.Invoices.Add(invoice);
            db.SaveChanges();

            RefInvoice = invoice.Id;
        }
        public static int Getinvoice_Identity()
        {
            int intResult = 0;
            erp_dataEntities2 db = new erp_dataEntities2();
            List<Invoice> list= db.Invoices.OrderByDescending(x=>x.Id).ToList();

            if (list.Count == 0)
                intResult = 1;
            else
                intResult = list[0].Id + 1;

            return intResult;
        }
        public static int getInvoicesNumber()
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);

            return db.Invoices.Where(x => x.CreationDate > date && x.type == 0).ToList().Count;

        }

        public static int getDevisesNumber()
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);

            return db.Invoices.Where(x => x.CreationDate > date && x.type == 1).ToList().Count;

        }

        public static int getCommandNumber()
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            DateTime date = DateTime.Now;
           date =  date.AddDays(-1);

            return db.Invoices.Where(x => x.CreationDate > date && x.type == 2).ToList().Count;

        }


        public static void AddInvoiceItems(List<VMInvoiceItem> ListItems, int RefInvoice, bool IsInvoice)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            foreach (VMInvoiceItem item in ListItems)
            {

                InvoiceItem IvItem = new InvoiceItem()
                {   
                    Code = item.Reference,
                    IdInvoice = RefInvoice,
                    quantity = item.Quantity,
                    TotalPrice = Convert.ToDecimal(item.TotalPrice),
                    totalPriceHT = Convert.ToDecimal((item.UnitPrice * item.Quantity) * item.Quantity),
                    totalTVA = Convert.ToDecimal((item.TVA * item.Quantity)),
                    UnitPriceHT = Convert.ToDecimal(item.UnitPrice * item.Quantity)
                };

                if (IsInvoice)
                {
                    Product P = db.Products.Where(x => x.Code == item.Reference).FirstOrDefault();
                    P.Amount = P.Amount - item.Quantity;
                    ProductsManager.Update(P);
             
                }
                db.InvoiceItems.Add(IvItem);
                db.SaveChanges();


            }
        }

        public static List<InvoiceItem> GetListInvoiceItems(int Id)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            return db.InvoiceItems.Where(x => x.IdInvoice == Id).ToList();

        }

        public static List<Invoice> GetInvoicesList(int Number)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            switch (Number)
            {
                case 1:
                 return db.Invoices.Where(x => x.type == 1).OrderByDescending(x => x.CreationDate).ToList();
                    break;
                case 2:
                    return db.Invoices.Where(x => x.type == 0).OrderByDescending(x => x.CreationDate).ToList();
                    break;
                case 3:
                    return db.Invoices.OrderByDescending(x => x.CreationDate).ToList();
                    break;
            }
            return null;
        }
           
        

        public static Invoice GetInvoice(int Id)
        {
            erp_dataEntities2 db = new erp_dataEntities2();

            return db.Invoices.Where(x => x.Id == Id).FirstOrDefault();
        }

        public static List<VM.VMFD> getListVMFD(int number)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            List<VMFD> list = new List<VMFD>();
            var AA = (from n in db.Invoices
                      join c in db.Clients
                      on n.IdClient equals c.Id

                      select new
                      {
                          Number = n.Id,
                          CreationDate = n.CreationDate,
                          TotalPrice = n.TotalPrice,
                          Client_Title = c.Title,
                          status = n.status,
                          PaymentType = n.PaymentType,
                          type = n.type,
                          ExpirationDate = n.ExpirationDate

                      }).OrderByDescending(x=>x.CreationDate).ToList();

            for (int i = 0; i < AA.Count - 1; i++)
            {
                VMFD vmfd = new VMFD()
                {
                    Id = AA[i].Number.ToString(),
                    CreationDate = AA[i].CreationDate,
                    TotalPrice = AA[i].TotalPrice +" DT",
                    Client_Title = AA[i].Client_Title,
                    status = AA[i].status,
                    PaymentType = AA[i].PaymentType,
                    type = AA[i].type,
                    ExpirationDate = AA[i].ExpirationDate

                };

                switch (number)
                {
                    case 1:
                        if(vmfd.type == 0)
                            list.Add(vmfd); break;
                    case 2:
                        if (vmfd.type == 1)
                            list.Add(vmfd); break;
                    case 3:
                        list.Add(vmfd); break;


                }
                


            }
   return list;
        }
    }
}
