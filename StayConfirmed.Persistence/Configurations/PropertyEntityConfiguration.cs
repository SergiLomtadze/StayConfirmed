using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;

namespace StayConfirmed.Persistence.Configurations;

public class PropertyEntityConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsUnicode();
        builder.Property(p => p.Address)
            .HasMaxLength(300)
            .IsUnicode();
        builder.Property(p => p.Country)
            .HasMaxLength(100)
            .IsUnicode();
        builder.Property(p => p.StarCategory)
            .HasMaxLength(50)
            .IsUnicode();
        builder.Property(p => p.ChainName)
            .HasMaxLength(200)
            .IsUnicode();
        builder.Property(p => p.GiataCode)
            .HasMaxLength(100)
            .IsUnicode();
    }
}
