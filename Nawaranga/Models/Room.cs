using Nawaranga.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Nawaranga.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Room Number")]
        [Required(ErrorMessage = "Required")]
        public int RoomNo { get; set; }

        [Required(ErrorMessage = "Required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Required")]
        public double Price { get; set; }

        [Display(Name = "Booking Start Date")]
        [Required(ErrorMessage = "Required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Booking End Date")]
        [Required(ErrorMessage = "Required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Required")]
        public RoomType RoomType { get; set; }

        [Display(Name = "Room Picture")]
        [Required(ErrorMessage = " Picture is required")]
        public string? PictureURL { get; set; }
        public List<Room_Guest>? Rooms_Guests { get; set; }


    }
}
