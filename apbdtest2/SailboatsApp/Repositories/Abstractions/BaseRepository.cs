using Microsoft.EntityFrameworkCore;
using SailboatsApp.Persistence;

namespace SailboatsApp.Repositories.Abstractions
{
    public abstract class BaseRepository
    {
        protected readonly BooksDbContext _dbContext;

        protected BaseRepository(BooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}