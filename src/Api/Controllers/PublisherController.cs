using Core.Dtos.Publisher;
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
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        public async Task<ActionResult<PublisherResponseDto>> Create(CreatePublisherRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var response = await _publisherService.CreateAsync(request, email);

            var uri = new Uri(Request.GetEncodedUrl() + "/" + response.Id);

            return Created(uri, response);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PublisherResponseDto>>> GetPublishers()
        {
            var response = await _publisherService.GetPublishersAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherResponseDto>> GetPublisher(int id)
        {
            var response = await _publisherService.GetPublisherAsync(id);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            await _publisherService.DeleteAsync(id, email);

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult<PublisherResponseDto>> Update(UpdatePublisherRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var response = await _publisherService.UpdateAsync(request, email);

            return Ok(response);
        }
    }
}
