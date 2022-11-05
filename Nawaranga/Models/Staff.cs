using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Nawaranga.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        public string? FullName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [Display(Name = "Position")]
        public string? Position { get; set; }

        [Display(Name = "Service Start Date")]
        [Required(ErrorMessage = "Required")]
        public DateTime ServiceDate { get; set; }

    }
}
