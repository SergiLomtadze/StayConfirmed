using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;

namespace StayConfirmed.Persistence.Configurations;

public class WalletEntityConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.Property(e => e.CurrentBalance)
            .HasDefaultValue(decimal.Zero)
            .ValueGeneratedOnAdd()
            .HasPrecision(18, 2);
    }
}