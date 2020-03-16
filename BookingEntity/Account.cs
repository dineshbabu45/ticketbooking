using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBooking.Entity
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string EmailId { get; set; }
       
        public string Password { get; set; }
       
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
      
        public byte Age { get; set; }
        
        public string Gender { get; set; }
        public bool IsAdmin { get; set; }
    }
}
