using Microsoft.EntityFrameworkCore;
using SailboatsApp.Models.Domain;

namespace SailboatsApp.Persistence
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BooksDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}