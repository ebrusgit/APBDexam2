using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.IdBook);
            builder.Property(b => b.Title).HasMaxLength(200).IsRequired();
            builder.Property(b => b.ReleaseDate).IsRequired();
            
            builder.HasOne(b => b.PublishingHouse)
                .WithMany(ph => ph.Books)
                .HasForeignKey(b => b.IdPublishingHouse);
            
            builder.HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity(j => j.ToTable("BookAuthors"));
            
            builder.HasMany(b => b.Genres)
                .WithMany(g => g.Books)
                .UsingEntity(j => j.ToTable("BookGenres"));
        }
    }
}