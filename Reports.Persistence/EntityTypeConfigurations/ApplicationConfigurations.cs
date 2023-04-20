using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using Applications.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoboxPersistence.EntityTypeConfiguration
{
    public class ApplicationConfigurations : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(applcation=> applcation.Id);
            builder.HasIndex(applcation => applcation.Id).IsUnique();
        }
    }
}
