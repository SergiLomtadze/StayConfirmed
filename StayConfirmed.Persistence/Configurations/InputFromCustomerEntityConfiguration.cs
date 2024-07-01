using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations;

public class InputFromCustomerEntityConfiguration : IEntityTypeConfiguration<InputFromCustomer>
{
    public void Configure(EntityTypeBuilder<InputFromCustomer> builder)
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
        builder.Property(x => x.Paxes)
            .HasJsonConversion()
            .HasJsonToCollectionComparer();
    }
}