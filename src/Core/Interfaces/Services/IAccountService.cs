using Core.Dtos.User;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IAccountService
    {
        public Task<UserResponseDto> Register(UserRegisterRequest request);
        public Task<UserResponseDto> SignIn(UserLoginRequest request);
        public Task<UserResponseDto> GetCurrentUser();
    }
}
