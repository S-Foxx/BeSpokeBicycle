using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeSpokeApp.Repository.Models
{
    [Table("Salesperson")]
    public partial class Salesperson
    {
        [Key]
        public int SalesPersonId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Address { get; set; } = null!;
        [StringLength(12)]
        [Unicode(false)]
        public string Phone { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TerminationDate { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Manager { get; set; } = null!;
    }
}
