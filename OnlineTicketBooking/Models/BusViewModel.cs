using System.ComponentModel.DataAnnotations;


namespace OnlineTicketBooking.Models
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
        [Required]
        public string BusType { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public byte SeatsAvailable { get; set; }
        [Required]
        public string StartPoint { get; set; }
        [Required]
        public string EndPoint { get; set; }

    }
}