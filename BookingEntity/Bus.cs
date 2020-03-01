using System;
using System.ComponentModel.DataAnnotations;

namespace BusBooking.Entity
{
    public class Bus
    {
       
        [Required]
        public string TravelsName { get; set; }

        [Required]
        public int BusId { get; set; }
        [Required]
        public string SourceCity { get; set; }
        [Required]
        public string DestinationCity { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
