using Nawaranga.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Nawaranga.Models
{
    public class Guest: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        public string? FullName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        public string? Address { get; set; }

        [Display(Name = "Purpose of Visit")]
        public string? Purpose { get; set; }

        [Display(Name = "Arrival Date")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        public DateTime Arrival { get; set; }

        [Display(Name = "Departure Date")]
        [Required(ErrorMessage = "Value is required and can't be empty!")]
        public DateTime Departure { get; set; }

        //Relationships

        //public List<Room_Guest>? Rooms_Guests { get; set; }

    }
}
