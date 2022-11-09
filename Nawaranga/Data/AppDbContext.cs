using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nawaranga.Models;

namespace Nawaranga.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        

        //Defining TableName for each models

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Guest> Guests { get; set; }

        //public DbSet<Room_Guest> Rooms_Guests { get; set; }

        public DbSet<Staff> Staffs { get; set; }

    }
}
