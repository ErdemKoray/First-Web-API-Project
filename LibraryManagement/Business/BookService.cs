using LibraryManagement.Data.Abstract;
using LibraryManagement.Models;
using LibraryManagement.Models.CreateDtos;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.Business
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Response> AddBookAsync(BookCreateDto bookCreateDto)
        {
            var Response = new Response();
            try
            {
                var Book = new Book()
                {
                    Title = bookCreateDto.Title,
                    ISBN = bookCreateDto.ISBN,
                    PublishedDate = bookCreateDto.PublishedDate,
                    Genre = bookCreateDto.Genre,
                    PageCount = bookCreateDto.PageCount,
                    Language = bookCreateDto.Language
                };
                await _bookRepository.AddAsync(Book);
                await _bookRepository.SaveAsync();
                Response.Data = Book;
                Response.Message = "Book added successfully.";
            }
            catch (Exception ex) 
            {
                Response.Success = false;
                Response.Message = $"An error occurred while adding the book : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> DeleteBookAsync(int id)
        {
            var Response = new Response();
            try
            {
                var Book = await _bookRepository.GetByIdAsync(id);
                if (Book == null) 
                {
                    Response.Success= false;
                    Response.Message = "Book not found.";
                }
                else
                {
                    await _bookRepository.DeleteAsync(Book);
                    await _bookRepository.SaveAsync();
                    Response.Message = "Book deleted successfully.";
                }
            }
            catch (Exception ex) 
            {
                Response.Success = false;
                Response.Message = $"An error occurred while deleting the book : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> GetAllBooksAsync()
        {
            var Response = new Response(); ;
            try
            {
                var Books = await _bookRepository.GetAllAsync();
                if (Books == null)
                {
                    Response.Success= false;
                    Response.Message = "Books not found.";
                }
                else
                {
                    Response.Data=Books;
                    Response.Message = "Books retrieved successfully.";
                }
            }
            catch (Exception ex) 
            {
                Response.Success = false;
                Response.Message = $"An error occurred while retrieving the books : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> GetBookByIdAsync(int id)
        {
            var Response = new Response();
            try
            {
                var Book = await _bookRepository.GetByIdAsync(id);
                if (Book == null)
                {
                    Response.Success = false;
                    Response.Message = "Book not found.";
                }
                else
                {
                    Response.Data = Book;
                    Response.Message = "Book retrieved successfully.";
                }
            }
            catch (Exception ex) 
            {
                Response.Success = false;
                Response.Message = $"An error occurred while retrieving the book : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> UpdateBookAsync(int id, BookCreateDto bookCreateDto)
        {
            var Response = new Response();
            try
            {
                var Book = await _bookRepository.GetByIdAsync(id);
                if (Book == null)
                {
                    Response.Success = false;
                    Response.Message = "Book not found.";
                }
                else
                {
                    Book.Title = bookCreateDto.Title;
                    Book.ISBN = bookCreateDto.ISBN;
                    Book.PublishedDate = bookCreateDto.PublishedDate;
                    Book.Genre = bookCreateDto.Genre;
                    Book.PageCount = bookCreateDto.PageCount;
                    Book.Language = bookCreateDto.Language;
                    await _bookRepository.UpdateAsync(Book);
                    await _bookRepository.SaveAsync();
                    Response.Data = Book;
                    Response.Message = "Book updated successfully.";
                }
            }
            catch(Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while updating the book : {ex.Message}";
            }
            return Response;
        }
    }
}
