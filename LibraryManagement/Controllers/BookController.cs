using LibraryManagement.Business;
using LibraryManagement.Models;
using LibraryManagement.Models.CreateDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllBooksAsync()
        {
            var Result = await _bookService.GetAllBooksAsync();
            if (Result.Success)
                return Ok(Result);
            return BadRequest(Result.Message);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetBookByIdAsync(int id)
        {
            var Result = await _bookService.GetBookByIdAsync(id);
            if (Result.Success) 
                return Ok(Result);
            return BadRequest(Result.Message);
        }
        [HttpPost]
        public async Task<ActionResult<Response>> AddBookAsync(BookCreateDto bookCreateDto)
        {
            var Result = await _bookService.AddBookAsync(bookCreateDto);
            if (Result.Success)
                return Ok(Result);
            return BadRequest(Result.Message);
        }
        [HttpPut]
        public async Task<ActionResult<Response>> UpdateBookAsync(int id, BookCreateDto bookCreateDto)
        {
            var Result = await _bookService.UpdateBookAsync(id, bookCreateDto);
            if(Result.Success)
                return Ok(Result);
            return BadRequest(Result.Message);
        }
        [HttpDelete]
        public async Task<ActionResult<Response>> DeleteBookAsync(int id)
        {
            var Result = await _bookService.DeleteBookAsync(id);
            if(Result.Success)
                return Ok(Result);
            return BadRequest(Result.Message);
        }
    }
}