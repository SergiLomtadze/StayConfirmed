using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;

namespace StayConfirmed.Persistence.Configurations
{
    public class MapProviderEntityConfiguration : IEntityTypeConfiguration<MapProvider>
    {
        public void Configure(EntityTypeBuilder<MapProvider> builder)
        {
            builder.Property(m => m.CustomerProvidedCode)
                .HasMaxLength(100);
        }
    }
}
