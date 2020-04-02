using BusBooking.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicketBooking.Models
{
    public class BookingViewModel
    {
        
        public int BusId { get; set; }
       
        public byte SeatsAvailable { get; set; }
        [Required]
        public string SeatNumbers { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public string TravelsName { get; set; }
        [Required]
        public string SourceCity { get; set; }
        [Required]
        public string DestinationCity { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string StartPoint { get; set; }
       
        [Required]
        public string BusTime { get; set; }
        [Required]
        public string EndPoint { get; set; }
    
        public virtual Bus Bus { get; set; }
    }
}