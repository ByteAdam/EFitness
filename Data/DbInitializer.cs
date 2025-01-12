using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using EFitness.Models;

namespace EFitness.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Create roles if they don't exist
            string[] roles = { "Staff", "Admin" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create a default admin user
            var adminEmail = "admin@efitness.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var newAdmin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User"
                };
                await userManager.CreateAsync(newAdmin, "Admin@123");
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
        }

        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<EFitnessContext>();

            // Seed Members
            if (!context.Members.Any())
            {
                context.Members.Add(new Member
                {
                    FullName = "Test Member",
                    Email = "test@example.com",
                    Phone = "1234567890",
                    Goals = "Fitness Goals"
                });
                await context.SaveChangesAsync();
            }

            // Seed Activities
            if (!context.Activities.Any())
            {
                context.Activities.Add(new Activity1
                {
                    Name = "Yoga",
                    Description = "Morning Yoga Session",
                    Schedule = DateTime.Parse("2024-01-01T08:00:00") 
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
