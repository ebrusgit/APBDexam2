using Microsoft.EntityFrameworkCore;
using SailboatsApp.Models.Domain;
using SailboatsApp.Persistence;
using SailboatsApp.Repositories.Abstractions;

namespace SailboatsApp.Repositories
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(BooksDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Genres.ToListAsync(cancellationToken);
        }
    }
}