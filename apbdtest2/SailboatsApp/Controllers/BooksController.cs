using Microsoft.AspNetCore.Mvc;
using SailboatsApp.Models.Requests;
using SailboatsApp.Services.Abstractions;

namespace SailboatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks(DateTime? releaseDateFilter, CancellationToken cancellationToken)
        {
            var books = await _bookService.GetAllBooksAsync(releaseDateFilter, cancellationToken);
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookDto request, CancellationToken cancellationToken)
        {
            try
            {
                var bookId = await _bookService.AddBookAsync(request, cancellationToken);
                return StatusCode(201, bookId);
            }
            catch (ArgumentException exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}