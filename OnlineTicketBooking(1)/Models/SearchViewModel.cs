using BusBooking.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicketBooking.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage ="Reqiured")]
        public string SourceCity { get; set; }
        [Required(ErrorMessage = "Reqiured")]
        public string DestinationCity { get; set; }
        public IEnumerable<Bus> Buses { get; set; }
    }
}