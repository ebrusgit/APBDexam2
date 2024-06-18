using SailboatsApp.Models.Requests;
using SailboatsApp.Models.Responses;

namespace SailboatsApp.Services.Abstractions
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDto>> GetAllBooksAsync(DateTime? releaseDateFilter, CancellationToken cancellationToken);
        Task<int> AddBookAsync(CreateBookDto request, CancellationToken cancellationToken);
    }
}