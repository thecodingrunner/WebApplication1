using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookService
    {
        private readonly BookModel _bookModel;
        private readonly AuthorModel _authorModel;
        public BookService(BookModel bookModel, AuthorModel authorModel)
        {
            _bookModel = bookModel;
            _authorModel = authorModel;
        }

        public Book? AddBook(Book book)
        {
            var authorToFind = book.Author;
            var authors = _authorModel.FetchAllAuthors();
            Console.WriteLine(authors);

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

        public void DeleteBook(int id)
        {
            _bookModel.DeleteBook(id);
        }
    }
}
