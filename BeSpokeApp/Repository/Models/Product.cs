using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeSpokeApp.Repository.Models
{
    public partial class Product
    {
        public Product()
        {
            Discounts = new HashSet<Discount>();
        }

        [Key]
        public int ProductId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Manufacturer { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Style { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PurchasePrice { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal SalePrice { get; set; }
        public int QtyOnHand { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal CommissionPercentage { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<Discount> Discounts { get; set; }
    }
}
