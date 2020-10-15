using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicketBooking.Models
{
    public class CategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; }
    }
}