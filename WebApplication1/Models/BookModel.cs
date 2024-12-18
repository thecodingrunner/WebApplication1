using WebApplication1.Classes;
using System.Text.Json;

namespace WebApplication1.Models
{
    public class BookModel
    {
        public static string _booksPath = "Resources\\Books.json";
        public static string _authorsPath = "Resources\\Authors.json";

        public List<Book> FetchAllBooks()
        {
            string json = File.ReadAllText(_booksPath);
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(json)!;
            return books;
        }

        public Book? FetchBookById(int id)
        {
            return FetchAllBooks()
                .Where(book => book.Id == id)
                .FirstOrDefault();
        }

        public Book AddBook(Book book) 
        {
            var books = FetchAllBooks();
            book.Id = books.Select(book => book.Id).Max() + 1;
            books.Add(book);
            var json = JsonSerializer.Serialize(books);
            File.WriteAllText(_booksPath, json);
            return book;
        }

        public void DeleteBook(int id)
        {
            var books = FetchAllBooks();
            List<Book> newBooksList = books.Where(book => book.Id != id).ToList();
            var json = JsonSerializer.Serialize(newBooksList);
            File.WriteAllText(_booksPath, json);
        }

        public List<Book> GetBooksByAuthorId(int authorId)
        {
            string authorsJson = File.ReadAllText(_authorsPath);
            List<Author> authors = JsonSerializer.Deserialize<List<Author>>(authorsJson)!;
            string booksJson = File.ReadAllText(_booksPath);
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(booksJson)!;

            string Name = authors.Where(book => book.Id == authorId).FirstOrDefault()!.Name;
            List<Book> filteredBooks = books.Where(book => book.Author == Name).ToList();

            return filteredBooks;
        }
    }
}
