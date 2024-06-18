using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.IdGenre);
            builder.Property(g => g.Name).HasMaxLength(100).IsRequired();
        }
    }
}