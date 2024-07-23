using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations;

public class StakeholderEntityConfiguration : IEntityTypeConfiguration<Stakeholder>
{
    public void Configure(EntityTypeBuilder<Stakeholder> builder)
    {
        builder.Property(s => s.IsActive)
                .HasDefaultValue(true);
        builder.Property(s => s.Name)
               .HasMaxLength(200)
               .IsUnicode(true);
        builder.Property(s => s.Vat)
                .HasMaxLength(100)
                .IsUnicode(true);
        builder.Property(s => s.Email)
                .HasMaxLength(100)
                .IsUnicode(true);
        builder.Property(s => s.Phone)
                .HasMaxLength(100)
                .IsUnicode(true);
        builder.Property(s => s.Address)
               .HasMaxLength(300)
               .IsUnicode(true);
        builder.Property(s => s.City)
               .HasMaxLength(100)
               .IsUnicode(true);
        builder.Property(s => s.Zip)
               .HasMaxLength(30)
               .IsUnicode(true);
        builder.Property(s => s.Region)
               .HasMaxLength(100)
               .IsUnicode(true);
        builder.Property(s => s.Province)
               .HasMaxLength(100)
               .IsUnicode(true);


        builder.Property(s => s.StakeholderType)
               .HasMaxLength(100)
               .HasEnumToStringConversion();
    }
}