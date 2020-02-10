using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyInovicesEF.Tables
{
    public class CompanyContract
    {
        [Key, Column(Order = 0)]
        public string CompanyName { get; set; }
        [Key, Column(Order = 1)]
        public Guid ContractID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey ("CompanyName")]  
        public virtual Company Company { get; set; }
        [ForeignKey ("ContractID")]
        public virtual Contract Contracts { get; set; }
    }
}
