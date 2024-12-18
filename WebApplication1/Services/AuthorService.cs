using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AuthorService
    {
        private readonly AuthorModel _authorModel;
        public AuthorService(AuthorModel authorModel)
        {
            _authorModel = authorModel;
        }

        public void AddAuthor(Author author)
        {
            _authorModel.AddAuthor(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorModel.DeleteAuthor(id);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorModel.FetchAllAuthors();
        }

        public Author? GetAuthorById(int id)
        {
            return _authorModel.FetchAuthorById(id);
        }
    }
}
