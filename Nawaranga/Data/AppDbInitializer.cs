using Nawaranga.Data.Enum;
using Nawaranga.Models;

namespace Nawaranga.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            //creating app services

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //creating reference to appdbcontext file as it is used to send data to db or get the data from db

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                //guest

                if (!context.Guests.Any())
                {
                    context.Guests.AddRange(new List<Guest>()
                    {
                        new Guest()
                        {
                            //GuestId = 1,
                           FullName = "Eva",
                            Arrival = DateTime.Now,
                            Departure = DateTime.Now.AddDays(3),
                            Address = "Canberra, Australia",
                            Purpose="Tourists"
                        },
                        new Guest()
                        {
                           // GuestId=2,
                            FullName = "Adam",
                            Arrival = DateTime.Now,
                            Departure = DateTime.Now.AddDays(5),
                            Address = "Ottawa,Canada",
                            Purpose="Tourists"
                        },
                        new Guest()
                        {
                           // GuestId =3,
                            FullName = "Stephan",
                            Arrival = DateTime.Now,
                            Departure = DateTime.Now.AddDays(7),
                            Address = "Moscow,Russia",
                            Purpose="Tourists"
                        },

                        new Guest()
                        {
                           // GuestId =4,
                            FullName = "Algert",
                            Arrival = DateTime.Now,
                            Departure = DateTime.Now.AddDays(11),
                            Address = "New York,United States",
                            Purpose="Tourists"
                        }
                    });
                    context.SaveChanges();
                }

                //rooms

                if (!context.Rooms.Any())
                {
                    context.Rooms.AddRange(new List<Room>()
                    {
                        new Room()
                        {
                            //RoomId = 1,
                            RoomNo = 101,
                            PictureURL = "https://setupmyhotel.com/images/Room-Type-Single-Room.jpg?ezimgfmt=rs:300x250/rscb337/ng:webp/ngcb337",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            RoomType = RoomType.Single,
                            Description="Single Bed <br/> Free Wifi <br/> Attached bathroom <br/> WorkTable<br/> 24*7 Hot Shower ",
                            Price=1000

                        },

                        new Room()
                        {

                           RoomNo = 102,
                           PictureURL = "https://setupmyhotel.com/images/Room-Type-Double-Room.jpg?ezimgfmt=rs:300x250/rscb337/ng:webp/ngcb337",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(5),
                            RoomType = RoomType.Double,
                            Description="Double Bed <br/> Free Wifi <br/> Attached bathroom <br/> 24*7 Hot Shower ",
                            Price=1800

                        },

                        new Room()
                        {

                           RoomNo = 103,
                            StartDate = DateTime.Now,
                            PictureURL = "https://setupmyhotel.com/images/Room-Type-Adjoining-rooms.jpg?ezimgfmt=rs:275x183/rscb337/ng:webp/ngcb337",
                            EndDate = DateTime.Now.AddDays(7),
                            RoomType = RoomType.Adjoiningrooms,
                            Description="Adjoiningrooms<br/> Free Wifi <br/> Attached bathroom <br/> 24*7 Hot Shower ",
                            Price=3000

                        },

                        new Room()
                        {

                           RoomNo = 104,
                           PictureURL = "https://setupmyhotel.com/images/Room-Type-double-double-Room.jpg?ezimgfmt=rs:300x250/rscb337/ng:webp/ngcb337",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(11),
                            RoomType = RoomType.DoubleDouble,
                            Description="Doubled Beds <br/> Free Wifi <br/> Attached bathroom <br/> 24*7 Hot Shower ",
                            Price=2500

                        }

                    });

                    context.SaveChanges();
                }

                //staffs

                if (!context.Staffs.Any())
                {
                    context.Staffs.AddRange(new List<Staff>()
                    {
                        new Staff()
                        {
                            FullName="Samjhana",
                            Address="Sindhupalchowk",
                            Position="Housekeeper",
                            ServiceDate=DateTime.Now.AddDays(3),
                        },

                        new Staff()
                        {
                            FullName="Durga",
                            Address="Dhulikhel",
                            Position="Chef",
                            ServiceDate=DateTime.Now.AddDays(5),
                        },

                        new Staff()
                        {
                            FullName="Kanchan",
                            Address="Dhulikhel",
                            Position="Manager",
                            ServiceDate=DateTime.Now.AddDays(7),
                        },

                        new Staff()
                        {
                            FullName="Purna",
                            Address="Dhulikhel",
                            Position="Owner",
                            ServiceDate=DateTime.Now.AddDays(11),
                        },

                        new Staff()
                        {
                            FullName="Hectar",
                            Address="Kathmandu",
                            Position="Waiter",
                            ServiceDate=DateTime.Now.AddDays(15),
                        },
                    });

                    context.SaveChanges();
                }

                //Room_Guest
                if (!context.Rooms_Guests.Any())
                {
                    context.Rooms_Guests.AddRange(new List<Room_Guest>()
                    {
                        new Room_Guest()
                        {
                            RoomId = 1,
                            GuestId = 3
                        },

                        new Room_Guest()
                        {
                            RoomId = 2,
                            GuestId = 4
                        },

                        new Room_Guest()
                        {
                            RoomId = 4,
                            GuestId = 1
                        },

                        new Room_Guest()
                        {
                            RoomId = 3,
                            GuestId = 2
                        },

                    });


                    context.SaveChanges();

                }


            }
        }
    }
}
