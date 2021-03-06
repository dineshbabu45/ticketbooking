﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineTicketBooking.Models
{
    public class SignUpViewModel
    {
        public int UserId { get; set; }
        [Required]
        [EmailAddress]
        
        public string EmailId { get; set; }
        [Required]
        [MaxLength(16)]
        public string Password { get; set; }
        
        [Compare("Password")]
        [MaxLength(16)]
        public string ConfirmPassword { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public byte Age { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}