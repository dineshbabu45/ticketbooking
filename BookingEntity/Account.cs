using System;
using System.ComponentModel.DataAnnotations;

namespace BusBooking.Entity
{
    public class Account
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte Age { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
