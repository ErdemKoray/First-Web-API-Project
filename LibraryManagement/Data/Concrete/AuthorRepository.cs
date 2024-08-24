using LibraryManagement.Data.Abstract;
using LibraryManagement.Models;

namespace LibraryManagement.Data.Concrete
{
    public class AuthorRepository : BaseRepository<Author> , IAuthorRepository
    {
        public AuthorRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
