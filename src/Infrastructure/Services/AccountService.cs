using AutoMapper;
using Core.Dtos.User;
using Core.Entities.Identity;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public Task<UserResponseDto> GetCurrentUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserResponseDto> Register(UserRegisterRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserResponseDto> SignIn(UserLoginRequest request)
        {
            //ToDO Validator

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                //ToDo MyException
                throw new Exception("nie znaleziono użytkownika");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
                throw new Exception("Hasło nieprawidłowe");

            return new UserResponseDto { Email = user.Email, Token = await _tokenService.CreateToken(user) };

        }
    }
}
