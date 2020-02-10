using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyInovicesEF.Tables
{
    public class Company
    {
        [Key]
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public int StreetNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractEndDate { get; set; }
        public bool ContractStatus { get; set; }


        public virtual ICollection<CompanyContract> Contracts { get; set; }
        public virtual ICollection<CompanyInvoice> CompanyInvoices { get; set; }

    }
}
