using Microsoft.EntityFrameworkCore;
using EFitnessAPI.Models;

namespace EFitnessAPI.Data
{
    public class EFitnessContext : DbContext
    {
        public EFitnessContext(DbContextOptions<EFitnessContext> options) : base(options) { }

        // DbSets (tables)
        public DbSet<Member> Members { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Activity1> Activities { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
    }
}
