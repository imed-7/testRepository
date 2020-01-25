using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;

namespace erp.fwk
{
    public class UsersManager
    {

        public static User GetAdministrator()
        {
            erp_dataEntities2 db = new erp_dataEntities2();

            return db.Users.Where(x => x.id == 2).FirstOrDefault();
        }
        public static void UpdateAdministrator(User us)
        {

            erp_dataEntities2 db = new erp_dataEntities2();
            db.Entry(us).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public static List<Supplier> GetSuppliersList()
        {
            erp_dataEntities2 db = new erp_dataEntities2();

            return db.Suppliers.ToList();
        }
        public static Supplier GetSupplier(int id)
        {
            erp_dataEntities2 db = new erp_dataEntities2();

            return db.Suppliers.Where(x => x.Id == id).FirstOrDefault();
        }

        public static Client GetClient(int id)
        {
            erp_dataEntities2 db = new erp_dataEntities2();

            return db.Clients.Where(x=>x.Id == id).FirstOrDefault();
        }

        public static List<Client> GetList_Clients()
        {
            erp_dataEntities2 db = new erp_dataEntities2();

            return db.Clients.ToList();
        }

        public static List<Supplier> GetList_Fournisseurs()
        {
            erp_dataEntities2 db = new erp_dataEntities2();

            return db.Suppliers.ToList();
        }
        public static  Client GetClientByTitle(string title)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            return db.Clients.Where(x => x.Title == title).FirstOrDefault();
        }
        public static void AddClient(Client client)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            db.Clients.Add(client);
            db.SaveChanges();
        }
        public static void AddSupplier(Supplier supplier)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }

        public static void RemoveSupplier(int Id)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            Supplier supplier = db.Suppliers.Where(x => x.Id == Id).FirstOrDefault();
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
        }
        public static void UpdateSupplier(Supplier S)
        {

            erp_dataEntities2 db = new erp_dataEntities2();
            db.Entry(S).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public static void UpdateClient(Client C)
        {
            
            erp_dataEntities2 db = new erp_dataEntities2();
            db.Entry(C).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public static void Remove(int Id)
        {
            erp_dataEntities2 db = new erp_dataEntities2();
            Client C = db.Clients.Where(x => x.Id == Id).FirstOrDefault();

            if (C != null)
            {
                db.Clients.Remove(C);
                db.SaveChanges();
            }

        }
        public static void UpdateClient_state(int Id,int state)
        {

            erp_dataEntities2 db = new erp_dataEntities2();
            Client C = db.Clients.Where(x => x.Id == Id).FirstOrDefault();
            C.state = state;
            db.Entry(C).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public static void UpdateSupplier_state(int Id, int state)
        {

            erp_dataEntities2 db = new erp_dataEntities2();
            Supplier S = db.Suppliers.Where(x => x.Id == Id).FirstOrDefault();
            S.State = state;
            db.Entry(S).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

    }
}
