using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using Reports.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsPersistence.EntityTypeConfiguration
{
    public class ReportConfigurations : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(report=> report.Id);
            builder.HasIndex(report=> report.Id).IsUnique();
            builder.Property(report => report.Title).HasMaxLength(500);
        }
    }
}
