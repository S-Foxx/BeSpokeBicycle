using System;
using System.Collections.Generic;

namespace BeSpokeApp.Models
{
    public partial class Product
    {
        public Product()
        {
            Discounts = new HashSet<Discount>();
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string Style { get; set; } = null!;
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int QtyOnHand { get; set; }
        public decimal CommissionPercentage { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
