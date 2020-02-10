using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyInovicesEF.Tables
{
    public class CompanyInvoice
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyInvoiceId { get; set; }
        [Key, Column(Order = 1)]
        public string CompanyName { get; set; }
        public int ChargeID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey ("CompanyName")]
        public virtual Company Company { get; set; }
        [ForeignKey("ChargeID")]
        public virtual Charge Charge { get; set; }

    }
}
