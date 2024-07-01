using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;

namespace StayConfirmed.Persistence.Configurations;

public class CurrencyEntityConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.Property(s => s.Name)
               .HasMaxLength(50)
               .IsUnicode(true);
        builder.Property(s => s.Description)
               .HasMaxLength(100)
               .IsUnicode(true);
    }
}
