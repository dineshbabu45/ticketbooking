using BusBooking.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ticketbookingmvc.Models
{
    public class SearchViewModel
    {
        [Required]
        public string SourceCity { get; set; }
        [Required]
        public string DestinationCity { get; set; }
        public IEnumerable<Bus> Buses { get; set; }
    }
}