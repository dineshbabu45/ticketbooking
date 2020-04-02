using System;
using System.ComponentModel.DataAnnotations;


namespace OnlineTicketBooking.Models
{
    public class BusViewModel
    {
        [Required]
        public string TravelsName { get; set; }

        
        public int BusId { get; set; }
        [Required]
        [MaxLength(20)]
        public string SourceCity { get; set; }
        [Required]
        [MaxLength(20)]
        public string DestinationCity { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [MaxLength(20)]
        public string BusType { get; set; }
        [Required]
        [MaxLength(20)]
        public string Date { get; set; }
        [Required]
        public byte SeatsAvailable { get; set; }
        [Required]
        [MaxLength(20)]
        public string StartPoint { get; set; }
        
      
        public string BusTime { get; set; }
        [MaxLength(20)]
        public string EndPoint { get; set; }

    }
}