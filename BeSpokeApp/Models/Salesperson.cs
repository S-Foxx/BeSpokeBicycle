using System;
using System.Collections.Generic;

namespace BeSpokeApp.Models
{
    public partial class Salesperson
    {
        public Salesperson()
        {
            Sales = new HashSet<Sale>();
        }

        public int SalesPersonId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Manager { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
