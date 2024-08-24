using LibraryManagement.Data.Abstract;
using LibraryManagement.Models;
using LibraryManagement.Models.CreateDtos;

namespace LibraryManagement.Business
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Response> AddAuthorAsync(AuthorCreateDto authorCreateDto)
        {
            var Response = new Response();
            try
            {
                var Author = new Author()
                {
                    FirstName = authorCreateDto.FirstName,
                    LastName = authorCreateDto.LastName,
                    DateOfBirth = authorCreateDto.DateOfBirth,
                    Nationality = authorCreateDto.Nationality,
                    DateOfDeath = authorCreateDto.DateOfDeath
                };
                await _authorRepository.AddAsync(Author);
                Response.Data = Author;
                Response.Message = "Author Added Successfully";
                await _authorRepository.SaveAsync();
            }
            catch (Exception ex) 
            {
                Response.Success = false;
                Response.Message = $"An error occurred while adding the author: {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> DeleteAuthorAsync(int id)
        {
            var Response = new Response();
            try
            {
                var Author = await _authorRepository.GetByIdAsync(id);
                if (Author == null) 
                {
                    Response.Success=false;
                    Response.Message = "Author not found.";
                }
                else 
                {
                    await _authorRepository.DeleteAsync(Author);
                    await _authorRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while deleting the author:{ex.Message}";
            }
            return Response;
        }

        public async Task<Response> GetAllAuthorsAsync()
        {
            var Response = new Response();
            try
            {
                var Authors = await _authorRepository.GetAllAsync();
                if (Authors == null)
                {
                    Response.Success = false;
                    Response.Message = "Authors not found.";
                }
                else
                {
                    Response.Data = Authors;
                }
            }
            catch (Exception ex) 
            {
                Response.Success = false;
                Response.Message = $"An error occurred while retrieving the authors : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> GetAuthorByIdAsync(int id)
        {
            var Response = new Response();
            try
            {
                var Author = await _authorRepository.GetByIdAsync(id);
                if (Author == null)
                {
                    Response.Success = false; ;
                    Response.Message = "Author not found.";
                }
                else
                {
                    Response.Data = Author;
                }
            }
            catch (Exception ex) 
            {
                Response.Success= false;
                Response.Message = $"An error occurred while retrieving the author : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> UpdateAuthorAsync(int id, AuthorCreateDto authorCreateDto)
        {
            var Response = new Response();
            try
            {
                var Author = await _authorRepository.GetByIdAsync(id);
                if (Author == null)
                {
                    Response.Success = false;
                    Response.Message = "Author not found.";
                }
                else 
                {
                    Author.FirstName = authorCreateDto.FirstName;
                    Author.LastName = authorCreateDto.LastName;
                    Author.DateOfBirth = authorCreateDto.DateOfBirth;
                    Author.Nationality = authorCreateDto.Nationality;
                    Author.DateOfDeath = authorCreateDto.DateOfDeath;
                    await _authorRepository.UpdateAsync(Author);
                    await _authorRepository.SaveAsync();
                }

            }
            catch(Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while updating the author : {ex.Message}";
            }
            return Response;
        }
    }
}