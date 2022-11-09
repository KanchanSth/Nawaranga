using System.ComponentModel.DataAnnotations;

namespace Nawaranga.Models
{
    public class Login
    {
        [Display(Name ="Email Address")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Value is required and can't be empty!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
