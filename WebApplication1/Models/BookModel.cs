using WebApplication1.Classes;
using System.Text.Json;

namespace WebApplication1.Models
{
    public class BookModel
    {
        public static string _booksPath = "Resources\\Books.json";

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
    }
}
