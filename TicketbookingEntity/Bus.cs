﻿using System;
using System.Collections.Generic;
namespace Ticketbooking.Entity
{
    public class Bus
    {

        public string TravelsName { get; set; }
        public int BusId { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }
        public double Price { get; set; }

    }
}
