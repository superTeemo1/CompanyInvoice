using CompanyInovicesEF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = CompanyInovicesEF.Tables;

namespace CompanyInovicesEF.DAL
{
    public class Invoice
    {
        public List<DB.CompanyInvoice> GetAllInvoices()
        {
            using(var context = new MyContext())
            {
                return context.CompanyInvoices.ToList();
            }
        }
        public DB.CompanyInvoice GetInvoiceById(int ID, string companyName)
        {
            using (var context = new MyContext())
            {
                return context.CompanyInvoices.FirstOrDefault<DB.CompanyInvoice>(a => a.CompanyName == companyName && a.CompanyInvoiceId == ID);
            }
        }
        public bool AddNewInvoice(DB.CompanyInvoice invoice)
        {
            using (var context = new MyContext())
            {
                context.CompanyInvoices.Add(invoice);
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteInvoice(int ID, string companyName)
        {
            using (var context = new MyContext())
            {
                var dbInvoice = context.CompanyInvoices.SingleOrDefault(a => a.CompanyInvoiceId == ID && a.CompanyName == companyName);

                context.CompanyInvoices.Remove(dbInvoice);
                context.SaveChanges();
                return true;
            }
        }
        public DB.CompanyInvoice EditInvoice(DB.CompanyInvoice invoice)
        {
            using (var context = new MyContext())
            {
                if (invoice != null)
                {
                    context.Entry(invoice).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return invoice;
                }
                return null;
            }
        }

        public List<DB.Charge> GetAllCharges()
        {
            using (var context = new MyContext())
            {
                return context.Charges.ToList();
            }
        }

    }
}
