using BusBooking.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicketBooking.Models
{
    public class EditBusViewModel
    {
        public int BusId { get; set; }
        [Required]
        [MaxLength(20)]
        public string TravelsName { get; set; }

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

        [Required]
        public string BusTime { get; set; }
        [MaxLength(20)]
        [Required]
        public string EndPoint { get; set; }  
        public IEnumerable<Bus> Buses { get; set; }

    }
}