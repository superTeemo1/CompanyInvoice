using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyInvoicesWeb.Models
{
    public class Inovice
    {
        public int CompanyInvoiceId { get; set; }
        public int ChargeID { get; set; }
        public string CompanyName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Charge> Charges { get; set; }
        public List<Company> Companies { get; set; }

    }
}