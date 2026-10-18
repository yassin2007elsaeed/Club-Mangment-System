using Holstic_LastDance.Models;
using Microsoft.EntityFrameworkCore;

namespace Holstic_LastDance.AppDataContext
{
    public class AppDataContextt : DbContext
    {
        public AppDataContextt(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>()
                .HasMany(x => x.guests)
                .WithMany(x => x.Staffs);

            modelBuilder.Entity<Room>()
            .HasOne(x => x.Guest)
            .WithOne(x => x.Room)
            .HasForeignKey<Room>(x => x.GuestId);


            modelBuilder.Entity<Department>()
                .HasMany(x=> x.Staffs)
                .WithOne(x=> x.Department)
                .HasForeignKey(x => x.DepartmentId);

            modelBuilder.Entity<Room>()
                .HasIndex(x => x.RoomNumber).IsUnique();
        }
    }
}
