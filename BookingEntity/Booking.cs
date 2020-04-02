using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBooking.Entity
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        public int BusId { get; set; }
        //public int UserId { get; set; }
      
        public string SeatNumbers { get; set; }
        public DateTime BookingDate { get; set; }
       [Required(AllowEmptyStrings = false)]
        public string TravelsName { get; set; }
       [Required(AllowEmptyStrings = false)]

        public string SourceCity { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string DestinationCity { get; set; }

        public double Price { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string BusType { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Date { get; set; }
        [Required]
        public string BusTime { get; set; }
        [NotMapped]
        public byte AvailableSeats { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string StartPoint { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string EndPoint { get; set; }
        [ForeignKey("BusId")]
        public virtual Bus Bus { get; set; }
        
    }
}
