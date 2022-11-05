using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Nawaranga.Models
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        public string? FullName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [Display(Name = "Purpose of Visit")]
        public string? Purpose { get; set; }

        [Display(Name = "Arrival Date")]
        [Required(ErrorMessage = "Required")]
        public DateTime Arrival { get; set; }

        [Display(Name = "Departure Date")]
        [Required(ErrorMessage = "Required")]
        public DateTime Departure { get; set; }

        //Relationships

        public List<Room_Guest>? Rooms_Guests { get; set; }

    }
}
