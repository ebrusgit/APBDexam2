using SailboatsApp.Models.Domain;

namespace SailboatsApp.Repositories.Abstractions
{
    public interface IGenreRepository : IBaseRepository
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync(CancellationToken cancellationToken);
    }
}