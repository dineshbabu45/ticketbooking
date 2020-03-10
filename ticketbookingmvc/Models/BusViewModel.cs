using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ticketbookingmvc.Models
{
    public class BusViewModel
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
        public string BusType { get; set; }
        public byte SeatsAvailable { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }

    }
}