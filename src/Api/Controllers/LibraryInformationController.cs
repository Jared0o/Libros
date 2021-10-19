using Core.Dtos.Information;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryInformationController : ControllerBase
    {
        private readonly ILibraryInformation _libraryInformation;

        public LibraryInformationController(ILibraryInformation libraryInformation)
        {
            _libraryInformation = libraryInformation;
        }

        [HttpGet("homepage")]
        public async Task<ActionResult<HomePageInformation>> GetHomePageInformation()
        {
            var information = await _libraryInformation.GetHomePageInformation();

            return Ok(information);
        }
    }
}
