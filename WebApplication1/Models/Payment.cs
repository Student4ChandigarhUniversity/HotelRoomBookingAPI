using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        public DateTime PaymentDate { get; set; }
        [Required]
        public double PaymentAmount { get; set; }
        [Required]
        public string PaymentDescription { get; set; }
        public int CustomerId { get; set; }

        public Booking Booking { get; set; }
    }
}
