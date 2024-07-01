using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations
{
    public class PropertyContactEntityConfiguration : IEntityTypeConfiguration<PropertyContact>
    {
        public void Configure(EntityTypeBuilder<PropertyContact> builder)
        {
            builder.Property(x => x.Value)
                .HasMaxLength(100);
            builder.Property(x => x.Type)
               .HasMaxLength(100)
               .HasEnumToStringConversion();
            builder.Property(x => x.Source)
               .HasMaxLength(100)
               .HasEnumToStringConversion();
        }
    }
}
