using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyInovicesEF.Tables
{
    public class DbInitializer: DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed (MyContext context)
        {
            List<Charge> charges = new List<Charge>
                {
                    new Charge { ID = 1, Name = "Day", Rate = 0.2M},
                    new Charge { ID = 2, Name = "Night", Rate = 0.2M},
                    new Charge { ID = 3, Name = "Weekend", Rate = 0.2M}
                };
            context.Charges.AddRange(charges);

            context.Companies.Add(new Company { CompanyName = "BH Telecom", City = "Sarajevo", ContactPerson="Hamo Hamic", Email = "info@bih.net.ba", Phone ="062333666", Address = "Malta 5"});

            context.Lookups.Add(new Lookup { Name = "Tax amount", Type = "TAX", Value = "17" });
            
            base.Seed(context);
        }
    }
}
