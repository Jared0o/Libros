using Core.Entities.Identity;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
