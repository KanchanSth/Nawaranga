using Nawaranga.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Nawaranga.Models
{
    public class Staff: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        public string? FullName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        public string? Address { get; set; }

        [Display(Name = "Position")]
        public string? Position { get; set; }

        [Display(Name = "Service Start Date")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        public DateTime ServiceDate { get; set; }

    }
}
