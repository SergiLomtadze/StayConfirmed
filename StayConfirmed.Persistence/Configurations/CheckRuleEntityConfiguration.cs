using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations;

public class CheckRuleEntityConfiguration : IEntityTypeConfiguration<CheckRule>
{
    public void Configure(EntityTypeBuilder<CheckRule> builder)
    {
        builder.Property(c => c.Type)
            .HasEnumToStringConversion();
        builder.Property(c => c.Value)
            .HasMaxLength(200)
            .IsUnicode();
    }
}
