using System.ComponentModel.DataAnnotations;

namespace BusBooking.Entity
{
    public class Bus
    {
        [StringLength(30)]
        [Required(AllowEmptyStrings =false)]
        public string TravelsName { get; set; }
        [Key]
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
        
        public string Date { get; set; }
        public byte SeatsAvailable { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string StartPoint { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string EndPoint { get; set; }

    }
}
