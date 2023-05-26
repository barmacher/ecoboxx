using Applications.Domain;
using Ecobox.Domain;
using Ecobox.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

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

        private static void SeedUser(ModelBuilder modelBuilder, RoleType roleType, int id, string userName, string password)
        {
            var user = new User
            {
                Id = id,
                UserName = userName,
                Email = userName,
                NormalizedEmail = userName.Normalize(),
                NormalizedUserName = userName.Normalize(),
            };

            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, password);

            // Add the user to the database
            modelBuilder.Entity<User>().HasData(user);

            var userRole = new UserRole()
            {
                RoleId = (int)roleType,
                UserId = id
            };
            modelBuilder.Entity<UserRole>().HasData(userRole);
        }
        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            SeedUser(modelBuilder, RoleType.Manager, 1, "InitManager@gmail.com", "P@ssw0rd!");
            SeedUser(modelBuilder, RoleType.Admin, 2, "Admin@gmail.com", "P@ssw0rd!");

        }
    }
}
