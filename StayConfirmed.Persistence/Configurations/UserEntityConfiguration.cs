using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;

namespace StayConfirmed.Persistence.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(s => s.Name)
             .HasMaxLength(100)
             .IsUnicode(true);
        builder.Property(s => s.Surname)
             .HasMaxLength(100)
             .IsUnicode(true);
        builder.Property(u => u.Secret)
            .HasMaxLength(20)
            .IsUnicode();
        builder.Property(u => u.IsActive).HasDefaultValue(false).IsRequired().ValueGeneratedOnAdd();
    }
}
