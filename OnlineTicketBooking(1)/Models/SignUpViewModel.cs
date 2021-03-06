﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicketBooking.Models
{
    public class SignUpViewModel
    {
        [Required]
        [EmailAddress]
        
        public string EmailId { get; set; }
        [Required]
        [MaxLength(16)]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte Age { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}