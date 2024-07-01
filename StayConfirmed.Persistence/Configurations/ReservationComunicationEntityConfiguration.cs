using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;

namespace StayConfirmed.Persistence.Configurations;

public class ReservationComunicationEntityConfiguration : IEntityTypeConfiguration<ReservationComunication>
{
    public void Configure(EntityTypeBuilder<ReservationComunication> builder)
    {
        builder.Property(r => r.Note)
            .IsUnicode();
    }
}