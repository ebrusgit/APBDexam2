using Microsoft.EntityFrameworkCore;
using SailboatsApp.Models.Domain;
using SailboatsApp.Persistence;
using SailboatsApp.Repositories.Abstractions;

namespace SailboatsApp.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(BooksDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(DateTime? releaseDateFilter, CancellationToken cancellationToken)
        {
            var query = _dbContext.Books
                .Include(b => b.PublishingHouse)
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .AsQueryable();

            if (releaseDateFilter.HasValue)
            {
                query = query.Where(b => b.ReleaseDate >= releaseDateFilter.Value);
            }

            return await query.OrderByDescending(b => b.ReleaseDate)
                .ThenBy(b => b.PublishingHouse.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task AddBookAsync(Book book, CancellationToken cancellationToken)
        {
            await _dbContext.Books.AddAsync(book, cancellationToken);
        }
    }
}