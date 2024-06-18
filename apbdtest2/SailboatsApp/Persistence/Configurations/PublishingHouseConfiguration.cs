using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence.Configurations
{
    public class PublishingHouseConfiguration : IEntityTypeConfiguration<PublishingHouse>
    {
        public void Configure(EntityTypeBuilder<PublishingHouse> builder)
        {
            builder.HasKey(ph => ph.IdPublishingHouse);
            builder.Property(ph => ph.Name).HasMaxLength(200).IsRequired();
            builder.Property(ph => ph.Country).HasMaxLength(100).IsRequired();
            builder.Property(ph => ph.City).HasMaxLength(100).IsRequired();
        }
    }
}