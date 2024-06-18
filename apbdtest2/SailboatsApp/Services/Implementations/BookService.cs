using SailboatsApp.Models.Domain;
using SailboatsApp.Models.Requests;
using SailboatsApp.Models.Responses;
using SailboatsApp.Repositories.Abstractions;
using SailboatsApp.Services.Abstractions;

namespace SailboatsApp.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IPublishingHouseRepository _publishingHouseRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository,
                           IGenreRepository genreRepository, IPublishingHouseRepository publishingHouseRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _publishingHouseRepository = publishingHouseRepository;
        }

        public async Task<IEnumerable<BookResponseDto>> GetAllBooksAsync(DateTime? releaseDateFilter, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllBooksAsync(releaseDateFilter, cancellationToken);

            return books.Select(b => new BookResponseDto
            {
                IdBook = b.IdBook,
                Title = b.Title,
                ReleaseDate = b.ReleaseDate,
                PublishingHouse = new PublishingHouseDto
                {
                    IdPublishingHouse = b.PublishingHouse.IdPublishingHouse,
                    Name = b.PublishingHouse.Name,
                    Country = b.PublishingHouse.Country,
                    City = b.PublishingHouse.City
                },
                Authors = b.Authors.Select(a => new AuthorDto { IdAuthor = a.IdAuthor, Name = a.Name }).ToList(),
                Genres = b.Genres.Select(g => new GenreDto { IdGenre = g.IdGenre, Name = g.Name }).ToList()
            });
        }

        public async Task<int> AddBookAsync(CreateBookDto request, CancellationToken cancellationToken)
        {
            var publishingHouse = await _publishingHouseRepository.GetPublishingHouseByIdAsync(request.IdPublishingHouse, cancellationToken);
            if (publishingHouse == null)
            {
                publishingHouse = new PublishingHouse
                {
                    IdPublishingHouse = request.IdPublishingHouse,
                    Name = request.PublishingHouseName,
                    Country = request.Country,
                    City = request.City
                };

                await _publishingHouseRepository.AddPublishingHouseAsync(publishingHouse, cancellationToken);
            }

            var authors = await _authorRepository.GetAllAuthorsAsync(cancellationToken);
            var genres = await _genreRepository.GetAllGenresAsync(cancellationToken);

            var newBook = new Book
            {
                Title = request.Title,
                ReleaseDate = request.ReleaseDate,
                IdPublishingHouse = publishingHouse.IdPublishingHouse,
                Authors = authors.Where(a => request.AuthorIds.Contains(a.IdAuthor)).ToList(),
                Genres = genres.Where(g => request.GenreIds.Contains(g.IdGenre)).ToList()
            };

            await _bookRepository.AddBookAsync(newBook, cancellationToken);
            await _bookRepository.SaveChangesAsync(cancellationToken);

            return newBook.IdBook;
        }
    }
}
