using Applications.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoboxPersistence.EntityTypeConfiguration
{
    public class ApplicationConfigurations : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(applcation => applcation.Id);
            builder.HasIndex(applcation => applcation.Id).IsUnique();
        }
    }
}
