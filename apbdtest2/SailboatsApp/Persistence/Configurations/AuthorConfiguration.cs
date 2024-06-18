using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.IdAuthor);
            builder.Property(a => a.Name).HasMaxLength(100).IsRequired();
        }
    }
}