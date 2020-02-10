using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyInvoicesWeb.Models
{
    public class Charge
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}