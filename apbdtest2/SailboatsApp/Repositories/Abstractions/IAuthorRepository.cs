using SailboatsApp.Models.Domain;

namespace SailboatsApp.Repositories.Abstractions
{
    public interface IAuthorRepository : IBaseRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync(CancellationToken cancellationToken);
    }
}