using LibraryManagement.Models;
using LibraryManagement.Models.CreateDtos;

namespace LibraryManagement.Business
{
    public interface IAuthorService
    {
        Task<Response> GetAllAuthorsAsync();
        Task<Response> GetAuthorByIdAsync(int id);
        Task<Response> AddAuthorAsync(AuthorCreateDto authorCreateDto);
        Task<Response> UpdateAuthorAsync(int id,AuthorCreateDto authorCreateDto);
        Task<Response> DeleteAuthorAsync(int id);
    }
}
