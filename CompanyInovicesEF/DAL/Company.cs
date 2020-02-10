using CompanyInovicesEF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = CompanyInovicesEF.Tables;

namespace CompanyInovicesEF.DAL
{
    public class Company
    {
        public List<DB.Company> GetAllCompanies()
        {
            using(var context = new MyContext())
            {
                return context.Companies.ToList();
            }
        }

        public DB.Company GetCompanyByName(string companyName)
        {
            using(var context = new MyContext())
            {
                return context.Companies.FirstOrDefault<DB.Company>(a => a.CompanyName == companyName);
            }
        }

        public bool AddNewCompany(DB.Company company)
        {
            using(var context = new MyContext())
            {
                context.Companies.Add(company);
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteCompany(string companyName)
        {
            using (var context = new MyContext())
            {
                var dbCompany = context.Companies.SingleOrDefault( a => a.CompanyName == companyName);

                context.Companies.Remove(dbCompany);
                context.SaveChanges();
                return true;
            }
        }

        public DB.Company EditCompany(DB.Company company)
        {
            using (var context = new MyContext())
            {
             // var dbCompany=  context.Companies.SingleOrDefault(a => a.CompanyName == company.CompanyName);
                if(company != null)
                {
                    context.Entry(company).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return company;
                }
                return null;
            }
        }
    }
}
