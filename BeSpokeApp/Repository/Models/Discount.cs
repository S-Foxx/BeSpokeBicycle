using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeSpokeApp.Repository.Models
{
    [Table("Discount")]
    public partial class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "date")]
        public DateTime BeginDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal DiscountPercentage { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("Discounts")]
        public virtual Product Product { get; set; } = null!;
    }
}
