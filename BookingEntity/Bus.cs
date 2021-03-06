﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBooking.Entity
{
    public class Bus
    {
        [StringLength(30)]
        [Required(AllowEmptyStrings =false)]
        public string TravelsName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusId { get; set; }
        [StringLength(50),MinLength(3)]
        [Required(AllowEmptyStrings = false)]
        public string SourceCity { get; set; }
        [StringLength(50),MinLength(3)]
        [Required(AllowEmptyStrings = false)]
        public string DestinationCity { get; set; }

        public double Price { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string BusType { get; set; }
        
        [Required]
        public string BusTime { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public byte SeatsAvailable { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string StartPoint { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string EndPoint { get; set; }

    }
}
