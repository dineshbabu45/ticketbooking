﻿using System.ComponentModel.DataAnnotations;

namespace BusBooking.Entity
{
    public class Bus
    {

        public string TravelsName { get; set; }
        [Key]
        public int BusId { get; set; }

        public string SourceCity { get; set; }

        public string DestinationCity { get; set; }

        public double Price { get; set; }
        public string BusType { get; set; }
        public byte SeatsAvailable { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }

    }
}
