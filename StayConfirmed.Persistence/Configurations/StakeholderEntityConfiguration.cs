using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations;

public class StakeholderEntityConfiguration : IEntityTypeConfiguration<Stakeholder>
{
    public void Configure(EntityTypeBuilder<Stakeholder> builder)
    {
        builder.Property(s => s.BusinessName)
               .HasMaxLength(300)
               .IsUnicode(true);
        builder.Property(s => s.Address)
               .HasMaxLength(300)
               .IsUnicode(true);
        builder.Property(s => s.City)
               .HasMaxLength(100)
               .IsUnicode(true);
        builder.Property(s => s.State)
               .HasMaxLength(100)
               .IsUnicode(true);
        builder.Property(s => s.Vat)
               .HasMaxLength(100)
               .IsUnicode(true);
        builder.Property(s => s.StakeholderType)
               .HasMaxLength(100)
               .HasEnumToStringConversion();
    }
}