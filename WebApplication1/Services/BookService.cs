using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookService
    {
        private readonly BookModel _bookModel;
        public BookService(BookModel bookModel)
        {
            _bookModel = bookModel;
        }

        public List<Book> GetAllBooks()
        {
            return _bookModel.FetchAllBooks();
        }
    }
}
