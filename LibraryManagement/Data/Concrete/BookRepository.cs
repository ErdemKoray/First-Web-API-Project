using LibraryManagement.Data.Abstract;
using LibraryManagement.Models;

namespace LibraryManagement.Data.Concrete
{
    public class BookRepository : BaseRepository<Book> , IBookRepository
    {
        public BookRepository(DataContext dataContext): base(dataContext) { }
    }
}
