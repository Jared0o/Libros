using Core.Dtos.Author;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize(Policy = "MemberRoleRequire")]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorResponseDto>> CreateAsyc(CreateAuthorRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var response = await _authorService.CreateAuthorAsync(request, email);

            var uri = new Uri(Request.GetEncodedUrl() + "/" + response.Id);

            return Created(uri, response);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AuthorResponseDto>>> GetItemAsync()
        {
            var response = await _authorService.GetAuthorsAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponseDto>> GetAuthor(int id)
        {
            var response = await _authorService.GetAuthorAsync(id);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            await _authorService.DeleteAuthorAsync(id, email);

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult<AuthorResponseDto>> Update(UpdateAuthorRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var response = await _authorService.UpdateAuthorAsync(request, email);

            return Ok(response);
        }

    }
}
