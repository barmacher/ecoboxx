using Applications.Domain;
using Ecobox.Domain;
using Ecobox.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcoboxPersistence.DataSeeders
{
    public static class UserSeeder
    {
        public static void InitializeDefaultAppUsers(this ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            foreach (var roleType in Enum.GetValues<RoleType>())
            {
                var roleName = roleType.ToString();
                Console.WriteLine(roleName);
                var role = new Role()
                {
                    Id = (int)roleType,
                    Name = roleName,
                    ConcurrencyStamp = roleName,
                    NormalizedName = roleName.Normalize()
                };
                modelBuilder.Entity<Role>().HasData(role);
                Console.WriteLine(roleName);

            }
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            int userId = 1;
            var user = new User
            {
                Id = userId,
                UserName = "InitManager@gmail.com",
                Email = "InitManager@gmail.com",
            };

            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "P@ssw0rd!");

            // Add the user to the database
            modelBuilder.Entity<User>().HasData(user);

            var userRole = new UserRole()
            {
                RoleId = (int) RoleType.Manager,
                UserId = userId
            };
            modelBuilder.Entity<UserRole>().HasData(userRole);
        }
    }
}
