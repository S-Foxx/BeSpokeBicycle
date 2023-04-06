using System;
using System.Collections.Generic;

namespace BeSpokeApp.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime StartDate { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
