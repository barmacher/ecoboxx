using Microsoft.EntityFrameworkCore;
using Applications.Domain;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationsApp.Interfaces
{
    public interface IApplicationsDbContext
    {
        DbSet<Application> Applications { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
