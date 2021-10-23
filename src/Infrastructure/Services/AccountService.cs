using AutoMapper;
using Core.Dtos.User;
using Core.Entities.Enums;
using Core.Entities.Identity;
using Core.Interfaces.Services;
using Infrastructure.Exceptions;
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
        private readonly RoleManager<Role> _roleManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        public async Task<UserResponseDto> GetCurrentUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return new UserResponseDto { Email = user.Email, Token = await _tokenService.CreateToken(user) };
        }

        public async Task<UserResponseDto> Register(UserRegisterRequest request)
        {
            var user = new User { FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, UserName = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new RegisterException("We have got with register, please try again");

            var resultRole = await _userManager.AddToRoleAsync(user, RolesEnum.Member.ToString());

            if(!resultRole.Succeeded)
                throw new RegisterException("We have got with register, please try again");

            return new UserResponseDto { Email = user.Email, Token = await _tokenService.CreateToken(user) };
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

        public async Task<bool> CheckUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null) 
                throw new Exception("nie znaleziono użytkownika");

            return true;
        }
    }
}
