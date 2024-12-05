using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EFitness.Models;

namespace EFitness.Data
{
    public class EFitnessContext : IdentityDbContext<ApplicationUser>
    {
        public EFitnessContext(DbContextOptions<EFitnessContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Activity1> Activities { get; set; } // Maps Activity1 entity
public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
