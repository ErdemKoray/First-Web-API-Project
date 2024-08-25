using LibraryManagement.Business;
using LibraryManagement.Models;
using LibraryManagement.Models.CreateDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetAllAuthorsAsync()
        {
            var Result = await _authorService.GetAllAuthorsAsync();
            if(Result.Success)
                return Ok(Result);
            else return BadRequest(Result.Message);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetAuthorByIdAsync(int id)
        {
            var Result = await _authorService.GetAuthorByIdAsync(id);
            if(Result.Success)
                return Ok(Result);
            else return BadRequest(Result.Message);
        }
        [HttpPost]
        public async Task<ActionResult<Response>> AddAuthorAsync(AuthorCreateDto authorCreateDto)
        {
            var Result = await _authorService.AddAuthorAsync(authorCreateDto);
            if(Result.Success)
                return Ok(Result);
            else return BadRequest(Result.Message);
        }
        [HttpPut]
        public async Task<ActionResult<Response>> UpdateAuthorAsync(int id , AuthorCreateDto authorCreateDto)
        {
            var Result = await _authorService.UpdateAuthorAsync(id, authorCreateDto);   
            if (Result.Success)
                return Ok(Result);
            else return BadRequest(Result.Message);
        }
        [HttpDelete]
        public async Task<ActionResult<Response>> DeleteAuthorAsync(int id)
        {
            var Result = await _authorService.DeleteAuthorAsync(id);
            if (Result.Success)
                return Ok(Result);
            else return BadRequest(Result.Message);
        }
    }
}
