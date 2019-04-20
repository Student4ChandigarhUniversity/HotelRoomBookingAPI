using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public string CustomerEmailId { get; set; }
        [Required]
        public string CustomerGender { get; set; }
        [Required]
        public long ContactNumber { get; set; }
        [Required]
        public DateTime CustomerDateOfBirth { get; set; }
        [Required]
        public string CustomerPassword { get; set; }

        //Relationship
        public virtual List<Booking> Bookings { get; set; }
        
    }
}
