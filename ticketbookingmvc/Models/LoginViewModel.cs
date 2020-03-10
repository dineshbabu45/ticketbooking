using System.ComponentModel.DataAnnotations;
namespace ticketbookingmvc.Models
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