using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(e => e.Reason)
             .HasMaxLength(100)
             .HasEnumToStringConversion();
        builder.Property(e => e.Amount)
            .HasDefaultValue(decimal.Zero)
            .ValueGeneratedOnAdd()
            .HasPrecision(18, 2);
    }
}