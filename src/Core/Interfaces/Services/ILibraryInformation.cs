using Core.Dtos.Information;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ILibraryInformation
    {
        public Task<HomePageInformation> GetHomePageInformation();
    }
}
