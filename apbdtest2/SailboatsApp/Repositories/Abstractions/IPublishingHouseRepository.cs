using SailboatsApp.Models.Domain;

namespace SailboatsApp.Repositories.Abstractions
{
    public interface IPublishingHouseRepository : IBaseRepository
    {
        Task<PublishingHouse> GetPublishingHouseByIdAsync(int id, CancellationToken cancellationToken);
        Task AddPublishingHouseAsync(PublishingHouse publishingHouse, CancellationToken cancellationToken);
    }
}