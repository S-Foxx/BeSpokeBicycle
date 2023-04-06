using System;
using System.Collections.Generic;

namespace BeSpokeApp.Models
{
    public partial class Sale
    {
        public int ProductId { get; set; }
        public int SalesPersonId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SalesDate { get; set; }
        public int Id { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Salesperson SalesPerson { get; set; } = null!;
    }
}
