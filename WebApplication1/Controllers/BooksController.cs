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

        [HttpGet]
        [Route("[controller]/{id}")]
        public ActionResult<Book> GetBookById(int id) 
        {
            var book = _bookService.GetBookById(id);

            if (book == null) 
            {
                return NotFound($"Book with Id {id} not found");
            }
            return Ok(book);
        }
    }
}
