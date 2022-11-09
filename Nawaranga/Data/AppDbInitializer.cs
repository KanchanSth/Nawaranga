using Microsoft.AspNetCore.Identity;
using Nawaranga.Data.Enum;
using Nawaranga.Data.Static;
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

                


            }
        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@nawaranga.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Kanchan Shrestha",
                        UserName = "kanchan-stha",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Nawaranga@1234");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "User@12345");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}