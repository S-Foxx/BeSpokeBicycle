using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeSpokeApp.Repository.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Address { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string Phone { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
    }
}
