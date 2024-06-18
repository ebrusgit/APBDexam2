using SailboatsApp.Models.Domain;

namespace SailboatsApp.Repositories.Abstractions
{
    public interface IBookRepository : IBaseRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(DateTime? releaseDateFilter, CancellationToken cancellationToken);
        Task AddBookAsync(Book book, CancellationToken cancellationToken);
    }
}