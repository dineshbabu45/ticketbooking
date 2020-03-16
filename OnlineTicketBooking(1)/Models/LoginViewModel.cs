using System.ComponentModel.DataAnnotations;
namespace OnlineTicketBooking.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}