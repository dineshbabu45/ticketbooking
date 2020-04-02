using BusBooking.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicketBooking.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage ="Reqiured")]
        public string SourceCity { get; set; }
        [Required(ErrorMessage = "Reqiured")]
        public string DestinationCity { get; set; }
        [Required(ErrorMessage = "Reqiured")]
        public string Date { get; set; }
        public IEnumerable<Bus> Buses { get; set; }
    }
}