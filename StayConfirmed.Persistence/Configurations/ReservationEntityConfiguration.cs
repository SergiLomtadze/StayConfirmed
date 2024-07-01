using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations;

public class ReservationEntityConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(r => r.CustomerReservationCode)
            .HasMaxLength(100);
        builder.Property(r => r.ProviderReservationCode)
            .HasMaxLength(100);
        builder.Property(r => r.ProviderReservationCodeLocal)
            .HasMaxLength(100);
        builder.Property(r => r.RoomName)
            .HasMaxLength(100);
        builder.Property(r => r.MealPlane)
            .HasMaxLength(100);
        builder.Property(r => r.CustomerCodeForProperty)
            .HasMaxLength(100);
        builder.Property(r => r.ProviderCodeForProperty)
            .HasMaxLength(100);
        builder.Property(r => r.GiataCodeForProperty)
            .HasMaxLength(100);
        builder.Property(r => r.PropertyName)
            .HasMaxLength(300);
        builder.Property(r => r.PropertyAddress)
            .HasMaxLength(500);
        builder.Property(r => r.PropertyCounty)
            .HasMaxLength(100);
        builder.Property(r => r.PropertyEmail)
            .HasMaxLength(200);
        builder.Property(r => r.ContactEmail)
            .HasMaxLength(200);
        builder.Property(r => r.PricingModel)
            .HasMaxLength(10);
        builder.Property(x => x.Paxes)
            .HasJsonConversion()
            .HasJsonToCollectionComparer();
    }
}
