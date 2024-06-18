using Microsoft.EntityFrameworkCore;
using SailboatsApp.Models.Domain;
using SailboatsApp.Persistence;
using SailboatsApp.Repositories.Abstractions;

namespace SailboatsApp.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public AuthorRepository(BooksDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Authors.ToListAsync(cancellationToken);
        }
    }
}