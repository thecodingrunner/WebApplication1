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

        public List<Author> GetAllAuthors()
        {
            return _authorModel.FetchAllAuthors();
        }
    }
}
