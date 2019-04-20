using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmailId { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        public long UserContactNumber { get; set; }


        public virtual List<HotelType> HotelTypes { get; set; }
    }
}
