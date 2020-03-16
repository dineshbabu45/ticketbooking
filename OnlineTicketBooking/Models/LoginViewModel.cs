using System.ComponentModel.DataAnnotations;
namespace OnlineTicketBooking.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
         public string Password { get; set; }
    }
}