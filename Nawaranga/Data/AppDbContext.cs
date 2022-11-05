using Microsoft.EntityFrameworkCore;
using Nawaranga.Models;

namespace Nawaranga.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room_Guest>().HasKey(rm => new
            {
                rm.GuestId,
                rm.RoomId
            });

            //Joining Table

            modelBuilder.Entity<Room_Guest>().HasOne(r => r.Room).WithMany(rm => rm.Rooms_Guests).HasForeignKey(r => r.RoomId);

            modelBuilder.Entity<Room_Guest>().HasOne(r => r.Guest).WithMany(rm => rm.Rooms_Guests).HasForeignKey(r => r.GuestId);

            base.OnModelCreating(modelBuilder);  //to generate the default authentication table
        }

        //Defining TableName for each models

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Room_Guest> Rooms_Guests { get; set; }

        public DbSet<Staff> Staffs { get; set; }

    }
}
