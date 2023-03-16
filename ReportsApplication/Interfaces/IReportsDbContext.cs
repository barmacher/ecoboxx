using Microsoft.EntityFrameworkCore;
using Reports.Domain;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportsApplication.Interfaces
{
    public interface IReportsDbContext
    {
        DbSet<Report> Reports { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
