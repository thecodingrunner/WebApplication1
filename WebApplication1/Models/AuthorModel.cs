using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using WebApplication1.Classes;

namespace WebApplication1.Models
{
    public class AuthorModel
    {
        public List<Author> FetchAllAuthors()
        {
            string json = File.ReadAllText("Resources\\Authors.json");
            List <Author> authors = JsonSerializer.Deserialize<List<Author>>(json)!;
            return authors;
        }
    }
}
