using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Classes;

namespace WebApplication1.Controllers
{
    [Route("/api")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetBook()
        {
            var books = _bookService.GetAllBooks();
            if (books == null)
            {
                return NotFound($"Books do not exist.");
            }
            return Ok(books);
        }
    }
}
