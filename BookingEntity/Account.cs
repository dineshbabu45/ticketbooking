using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBooking.Entity
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string EmailId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(24), MinLength(8)]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50), MinLength(3)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]

        public byte Age { get; set; }
        [Required(AllowEmptyStrings = false)]
       
        public string Gender { get; set; }
        
        public bool IsAdmin { get; set; }
    }
}
