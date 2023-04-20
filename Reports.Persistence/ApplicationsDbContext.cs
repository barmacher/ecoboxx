using Microsoft.EntityFrameworkCore;
using Applications.Domain;
using ApplicationsApp.Interfaces;
using EcoboxPersistence.EntityTypeConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Ecobox.Domain;
using Microsoft.AspNetCore.Identity;

namespace EcoboxPersistence
{
    public class ApplicationsDbContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>, IApplicationsDbContext
    {
        public DbSet<Application> Applications { get; set; }

        public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationConfigurations());
            base.OnModelCreating(builder);
        }


    }
}
