using System.ComponentModel.DataAnnotations;

namespace Nawaranga.Models
{
    public class Register
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        public string FullName { get; set; }

        [Display(Name ="Email Address")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Value is required and can't be empty!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
