using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using DataSource;
using erp.fwk.VM;

using System.Runtime.Serialization;
using System.Collections;

namespace erp.fwk
{
    public class ProductsManager
    {
        
        public static List<Product> GetList()
        {
            erp_dataEntities2 db = new erp_dataEntities2();
           
            return db.Products.ToList();
        }

        public static void AddProduct(Product P)
        {
            P.LastUpdateDate = DateTime.Now;

            erp_dataEntities2 db = new erp_dataEntities2();
            db.Products.Add(P);
            db.SaveChanges();
    
        }

        public static void Remove(Product P)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            db.Products.Remove(P);
            db.SaveChanges();

        }
        public static void Remove(int Id)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            Product P = db.Products.Where(x => x.Id == Id).FirstOrDefault();
            db.Products.Remove(P);
            db.SaveChanges();

        }

        public static List<Category> GetListCategories()
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            return db.Categories.ToList();
        }

        public static Product GetProduct(int Id)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            Product P = db.Products.Where(x => x.Id == Id).FirstOrDefault();
            return P;
        }

        public static void Update(Product P)
        {
            P.LastUpdateDate = DateTime.Now;
            erp_dataEntities2 db = new erp_dataEntities2();
            db.Entry(P).State =System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public static List<VMInvoiceItem> AddProductToInvoice(string Title,int Amount,List<VMInvoiceItem> List) 
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            Product P = db.Products.Where(x => x.Title == Title).FirstOrDefault();
            VMInvoiceItem I = new VMInvoiceItem() {
                Reference = P.Code,
                Title = P.Title,
                UnitPrice = P.Price,
                TotalPrice = Amount * P.Price,
                TVA = 17,
                Quantity = Amount      
            };

            if(List.Where(x=>x.Reference == I.Reference).FirstOrDefault() == null)
               List.Add(I);

            return List;
        }

        public static VMProduct GetVMProduct(Product P)
        {
            if (P.IdCategory != null && P.IdSupplier != null)
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
                return VMP;
            }

            return null;
        }

        public static List<VMProduct> GetListVMProducts()
        {
            return GetListVMProducts(null);
        }

        public static List<VMProduct> GetListVMProducts(List<Product> list)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            List<Product> CurrentList = new List<Product>();
            List<VMProduct> ListVM = new List<VMProduct>();

            if (list != null)
                CurrentList = list;
            else
                CurrentList = db.Products.ToList();

        
            foreach(Product P in CurrentList)
            {
                if (P.IdCategory != null && P.IdSupplier != null)
                {
                   
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

                    ListVM.Add(VMP);
                }
                

            }

            return ListVM;
        }

        public static List<VMProduct> GetPageList_Products(List<VMProduct> list,int Number,int Page)
        {
            
            List<VMProduct> result = new List<VMProduct>();
            result.Clear();
            for (int i=(Number*Page) - Number; i< Number * Page ; i++)
            {
                if (i < list.Count)
                    result.Add(list[i]);
            }
            return result;
        }

        public static List<VME> GetList_Products(DateTime date,string Ref)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            List<Invoice> liste = db.Invoices./*Where(x => x.CreationDate >= DateTime.Now.AddDays(-10)).*/ToList();
            var AA = (from n in db.Invoices
                      join c in db.InvoiceItems
                      on n.Id equals c.IdInvoice
                      where c.Code == Ref
                      select new
                      {
                          code=c.Code,
                          CreationDate = n.CreationDate,

                          quantity = c.quantity

                      }).Take(10).ToList();
            List<VME> list = new List<VME>();
            List<string> ss = new List<string>();
            for (int i = 0; i < AA.Count - 1; i++)
            {
                int sum = 0;

                for (int j = i; j < AA.Count; j++)
                {

                    if (AA[i].CreationDate.ToShortDateString() == AA[j].CreationDate.ToShortDateString())
                    {

                        sum += AA[i].quantity;

                    }
                    if (!ss.Contains(AA[i].CreationDate.ToShortDateString()))
                    {
                        ss.Add(AA[i].CreationDate.ToShortDateString());

                        VME vme = new VME()
                        {
                            code = AA[i].code,
                            date = AA[i].CreationDate,
                            quantity = sum
                        };

                        list.Add(vme);
                    }
                }
                
            }
            return list;
        }
        public static List<string> VerifyAvailability(string Title)
        {
            return VerifyAvailability(Title,0);
        }



        public static List<string> VerifyAvailability(string Title, int quantity)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            List<string> ListError = new List<string> ();
            Product P = db.Products.Where(x=>x.Title == Title).FirstOrDefault();

            if(P != null)
            {
                #region verify quantity
                if (quantity > 0 && P.Amount < quantity)
                    if (!ListError.Contains(ErrorManager.Quantity_Product_NOT_AVAILABLE))
                        ListError.Add(ErrorManager.Quantity_Product_NOT_AVAILABLE);

                if (P.Amount <= 0)
                    ListError.Add(ErrorManager.Quantity_Product_NOT_AVAILABLE);
                #endregion
            }
            else
                ListError.Add(ErrorManager.PRODUCT_NOT_FOUND);

            #region verify unavailabitity period
            #endregion

            return ListError;
        }

        public static List<VME> GetProductBusiness(DateTime fromdate,DateTime todate,string reference)
        {

            

            List<VME> BusinessList = new List<VME>();
            erp_dataEntities2 db = new erp_dataEntities2();
            var list = (from n in db.Invoices
                        join c in db.InvoiceItems
                        on n.Id equals c.IdInvoice
                        join cl in db.Clients on n.IdClient equals cl.Id
                        where (n.CreationDate >= fromdate)
                        where (n.CreationDate < todate)
                        where c.Code == reference
                        group c by cl.Title into g
                        select  new
                        {
                            
                            quantity = g.Sum(c=>c.quantity),
                            Client_Title = g.Key
                   
                         

                        }).ToList();
            foreach(var item in list){
              Client client=  UsersManager.GetClientByTitle(item.Client_Title);
                VME vme = new VM.VME()
                {
                    quantity =item.quantity,
                    ClientTitle =item.Client_Title ,
                    code = reference,
                    color = client.Color
                };
                BusinessList.Add(vme);
            }

         

            return BusinessList;
        }

        public static bool ExistingProduct(Product P)
        {
            bool IsExist = false;
            erp_dataEntities2 db = new erp_dataEntities2();

            IsExist = db.Products.Where(x => x.Title == P.Title || x.Code == P.Code).ToList().Count() > 0;
            return IsExist;
        }
    }
}
