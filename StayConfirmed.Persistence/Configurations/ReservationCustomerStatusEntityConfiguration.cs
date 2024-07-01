using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.DataAccess.Enums;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations;

public class ReservationCustomerStatusEntityConfiguration : IEntityTypeConfiguration<ReservationCustomerStatus>
{
    public void Configure(EntityTypeBuilder<ReservationCustomerStatus> builder)
    {
        builder.Property(r => r.State)
            .HasDefaultValue(CustomerStatusState.Active)
            .IsRequired()
            .HasEnumToStringConversion();
        builder.Property(r => r.Language)
            .IsRequired()
            .HasMaxLength(10)
            .IsUnicode();
        builder.Property(r => r.Description)
            .IsRequired()
            .HasMaxLength(300)
            .IsUnicode();
    }
}
