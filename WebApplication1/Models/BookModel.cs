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
    }
}
