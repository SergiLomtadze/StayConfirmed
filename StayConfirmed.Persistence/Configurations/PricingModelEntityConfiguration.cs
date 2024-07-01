using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;

namespace StayConfirmed.Persistence.Configurations
{
    public class PricingModelEntityConfiguration : IEntityTypeConfiguration<PricingModel>
    {
        public void Configure(EntityTypeBuilder<PricingModel> builder)
        {
            builder.Property(e => e.Model)
                .HasMaxLength(20)
                .IsUnicode();
            builder.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode();
            builder.Property (e => e.Price)
                .HasDefaultValue(decimal.Zero)
                .ValueGeneratedOnAdd()
                .HasPrecision(18, 2);
        }
    }
}
