using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeSpokeApp.Repository.Models
{
    public partial class Sale
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SalesPersonId { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "date")]
        public DateTime SalesDate { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;
        [ForeignKey("SalesPersonId")]
        public virtual Salesperson SalesPerson { get; set; } = null!;
    }
}
