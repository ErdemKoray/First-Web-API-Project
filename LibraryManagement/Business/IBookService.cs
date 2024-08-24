using LibraryManagement.Models;
using LibraryManagement.Models.CreateDtos;

namespace LibraryManagement.Business
{
    public interface IBookService
    {
        Task<Response> GetAllBooksAsync();
        Task<Response> GetBookByIdAsync(int id);
        Task<Response> AddBookAsync(BookCreateDto bookCreateDto);
        Task<Response> UpdateBookAsync(int id,BookCreateDto bookCreateDto);
        Task<Response> DeleteBookAsync(int id);
    }
}
