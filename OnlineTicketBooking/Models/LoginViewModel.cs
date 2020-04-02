using System.ComponentModel.DataAnnotations;
namespace OnlineTicketBooking.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string EmailId { get; set; }
        [Required]
         public string Password { get; set; }
    }
}