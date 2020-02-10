using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyInovicesEF.Tables
{
    public class MyContext: DbContext
    {
        public MyContext() : base("CompanyInvoices") { Database.SetInitializer(new DbInitializer()); }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Charge> Charges { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<CompanyContract> CompanyContracts { get; set; }
        public virtual DbSet<CompanyInvoice> CompanyInvoices { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        
     }
}
