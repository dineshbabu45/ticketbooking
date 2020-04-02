using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicketBooking.Models
{
    public class EditUserViewModel
    {
        public int UserId { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public byte Age { get; set; }
    }
}