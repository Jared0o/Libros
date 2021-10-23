using Core.Dtos.Book;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<ActionResult<BookResponseDto>> Create(CreateBookRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var response = await _bookService.CreateBookAsync(request, email);

            var uri = new Uri(Request.GetEncodedUrl() + "/" + response.Id);

            return Created(uri, response);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BookResponseDto>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponseDto>> GetBook(int id)
        {
            var book = await _bookService.GetBookAsync(id);

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            await _bookService.DeleteAsync(id, email);

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult<BookResponseDto>> Update(UpdateBookRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var book = await _bookService.UpdateAsync(request, email);

            return Ok(book);
        }

        [HttpGet("books-by-email/{name}")]
        public async Task<ActionResult<List<BookResponseDto>>> BooksByName(string name)
        {
            var books = await _bookService.GetBooksByName(name);

            return Ok(books);
        }
    }
}
