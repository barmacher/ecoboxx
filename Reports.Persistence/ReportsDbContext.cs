using Microsoft.EntityFrameworkCore;
using Reports.Domain;
using ReportsApplication.Interfaces;
using ReportsPersistence.EntityTypeConfiguration;

namespace ReportsPersistence
{
    public class ReportsDbContext : DbContext, IReportsDbContext
    {
        public DbSet<Report> Reports { get; set; }

        public ReportsDbContext(DbContextOptions<ReportsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ReportConfigurations());
            base.OnModelCreating(builder);
        }


    }
}
