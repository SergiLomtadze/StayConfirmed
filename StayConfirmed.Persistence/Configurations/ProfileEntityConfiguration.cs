using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations;

public class ProfileEntityConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode();
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(300)
            .IsUnicode();
        builder.Property(p => p.IdRoles)
            .HasJsonConversion();
    }
}
