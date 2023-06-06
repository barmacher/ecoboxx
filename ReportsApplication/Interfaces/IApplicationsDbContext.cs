using Microsoft.EntityFrameworkCore;
using Applications.Domain;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecobox.Domain;

namespace ApplicationsApp.Interfaces
{
    public interface IApplicationsDbContext
    {
        DbSet<Application> Applications { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Role> Roles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
