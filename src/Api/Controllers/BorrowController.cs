using Core.Dtos.Borrow;
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
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _borrowService;

        public BorrowController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        [HttpPost]
        public async Task<ActionResult<BorrowResponseDto>> CreateBorrow(CreateBorrowRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var response = await _borrowService.CreateBorrowAsync(request, email);

            var uri = new Uri(Request.GetEncodedUrl() + "/" + response.Id);

            return Created(uri, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowController>> GetBorrow(int id)
        {
            var response = await _borrowService.GetBorrowAsync(id);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BorrowController>>> GetBorrows()
        {
            var response = await _borrowService.GetBorrowsAsync();

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> ReturnBook(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            await _borrowService.SetBorrowToReturnedAsync(id, email);

            return NoContent();
        }

    }
}
