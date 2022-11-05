namespace Nawaranga.Models
{
    public class Room_Guest
    {
        public int RoomId { get; set; }

        public Room? Room { get; set; }
        public int GuestId { get; set; }

        public Guest? Guest { get; set; }

    }
}
