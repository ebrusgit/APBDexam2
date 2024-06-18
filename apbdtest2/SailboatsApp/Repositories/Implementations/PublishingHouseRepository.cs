using Microsoft.EntityFrameworkCore;
using SailboatsApp.Models.Domain;
using SailboatsApp.Persistence;
using SailboatsApp.Repositories.Abstractions;

namespace SailboatsApp.Repositories
{
    public class PublishingHouseRepository : BaseRepository, IPublishingHouseRepository
    {
        public PublishingHouseRepository(BooksDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PublishingHouse> GetPublishingHouseByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.PublishingHouses.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddPublishingHouseAsync(PublishingHouse publishingHouse, CancellationToken cancellationToken)
        {
            await _dbContext.PublishingHouses.AddAsync(publishingHouse, cancellationToken);
        }
    }
}