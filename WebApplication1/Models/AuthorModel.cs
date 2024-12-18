using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using WebApplication1.Classes;

namespace WebApplication1.Models
{
    public class AuthorModel
    {
        public static string _authorsPath = "Resources\\Authors.json";
        public void AddAuthor(Author author)
        {
            var authors = FetchAllAuthors();
            author.Id = authors.Select(author => author.Id).Max() + 1;
            authors.Add(author);
            var json = JsonSerializer.Serialize(authors);
            File.WriteAllText(_authorsPath, json);
        }

        public void DeleteAuthor(int id)
        {
            var authors = FetchAllAuthors();
            List<Author> newAuthorsList = authors.Where(author => author.Id != id).ToList();
            var json = JsonSerializer.Serialize(newAuthorsList);
            File.WriteAllText(_authorsPath, json);
        }

        public List<Author> FetchAllAuthors()
        {
            string json = File.ReadAllText(_authorsPath);
            List <Author> authors = JsonSerializer.Deserialize<List<Author>>(json)!;
            return authors;
        }

        public Author? FetchAuthorById(int id)
        {
            return FetchAllAuthors()
                .Where(author => author.Id == id)
                .FirstOrDefault();
        }
    }
}
