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

        public Book? AddBook(Book book, AuthorService authorService)
        {
            var authorToFind = book.Author;
            var authors = authorService.GetAllAuthors();

            Author? foundAuthor = authors.Where(author => author.Name == authorToFind).FirstOrDefault();

            if (foundAuthor == null)
            {
                return null;
            }

            _bookModel.AddBook(book);
            return book;
        }

        public List<Book> GetAllBooks()
        {
            return _bookModel.FetchAllBooks();
        }

        public Book? GetBookById(int id)
        {
            return _bookModel.FetchBookById(id);
        }
    }
}
