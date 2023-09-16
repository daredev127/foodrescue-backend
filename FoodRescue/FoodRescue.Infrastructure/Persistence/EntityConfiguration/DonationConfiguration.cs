using FoodRescue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRescue.Infrastructure.Persistence.EntityConfiguration
{
    internal class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FoodType).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.UnitOfMeasure).HasMaxLength(20);
            builder.Property(x => x.Quantity).HasColumnType("decimal(18, 2)").IsRequired();
            builder.HasOne(x => x.User).WithMany().IsRequired();
        }
    }
}
