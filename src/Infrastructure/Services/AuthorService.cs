using AutoMapper;
using Core.Dtos.Author;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Interfaces.Services;
using Core.Validators.Author;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AuthorService(IAuthorRepository authorRepository, UserManager<User> userManager, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AuthorResponseDto> CreateAuthorAsync(CreateAuthorRequest request, string userEmail)
        {
            var validator = new CreateAuthorValidator();
            await validator.ValidateAndThrowAsync(request);            

            var user = await _userManager.FindByEmailAsync(userEmail);
            await _userManager.SetLockoutEnabledAsync(user, false);
            var author = _mapper.Map<Author>(request);

            author.CreatedBy = user;

            author = await _authorRepository.Create(author);

            var response = _mapper.Map<AuthorResponseDto>(author);

            return response;

        }

        public async Task DeleteAuthorAsync(int id, string userEmail)
        {
            //var user = await _userManager.FindByEmailAsync(userEmail);

            await _authorRepository.Delete(id);
            //TODO Logowanie usuniętych Autorow do pliku
        }

        public async Task<AuthorResponseDto> GetAuthorAsync(int id)
        {
            var author = await _authorRepository.GetItem(id);             

            var response = _mapper.Map<AuthorResponseDto>(author);

            return response;
        }

        public async Task<IReadOnlyList<AuthorResponseDto>> GetAuthorsAsync()
        {
            var authors = await _authorRepository.GetItems();

            var response = _mapper.Map<IReadOnlyList<AuthorResponseDto>>(authors);

            return response;
        }

        public async Task<AuthorResponseDto> UpdateAuthorAsync(UpdateAuthorRequest request, string userEmail)
        {            
            var validator = new UpdateAuthorValidator();
            await validator.ValidateAndThrowAsync(request);

            var user = await _userManager.FindByEmailAsync(userEmail);

            var author = _mapper.Map<Author>(request);

            author.UpdatedBy = user;
            author.Updated = DateTime.Now;

            author = await _authorRepository.Update(author);

            var response = _mapper.Map<AuthorResponseDto>(author);

            return response;
        }

        public async Task<IReadOnlyList<AuthorResponseDto>> GetAuthorsByName(string name)
        {
            var author = await _authorRepository.GetAuthorByName(name);

            var response = _mapper.Map<IReadOnlyList<AuthorResponseDto>>(author);

            return response;
        }
    }
}
