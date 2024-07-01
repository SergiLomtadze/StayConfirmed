using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.DataAccess.Enums;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations;

public class ReservationOperationalStatusEntityConfiguration : IEntityTypeConfiguration<ReservationOperationalStatus>
{
    public void Configure(EntityTypeBuilder<ReservationOperationalStatus> builder)
    {
        builder.Property(s => s.State)
            .HasDefaultValue(OprationalStatusState.NotChecked)
            .IsRequired()
            .HasEnumToStringConversion();
    }
}