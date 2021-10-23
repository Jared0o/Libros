using AutoMapper;
using Core.Dtos.Book;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public BookService(IBookRepository bookRepository, IMapper mapper, UserManager<User> userManager, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _userManager = userManager;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<BookResponseDto> CreateBookAsync(CreateBookRequest request, string email)
        {
            //TODO Validator

            var user = await _userManager.FindByEmailAsync(email);

            var author = await _authorRepository.GetItem(request.AuthorId);
            var publisher = await _publisherRepository.GetItem(request.PublisherId);

            var book = _mapper.Map<Book>(request);

            book.Author = author;
            book.Publisher = publisher;
            book.Created = DateTime.Now;
            book.CreatedBy = user;

            book = await _bookRepository.Create(book);

            var response = _mapper.Map<BookResponseDto>(book);

            return response;
        }

        public async Task DeleteAsync(int id, string email)
        {
            //TODO LOGOWANIE DO PLIKU
            //var user = await _userManager.FindByEmailAsync(userEmail);
            await _bookRepository.Delete(id);
        }

        public async Task<BookResponseDto> GetBookAsync(int id)
        {
            var book = await _bookRepository.GetItem(id);
            var response = _mapper.Map<BookResponseDto>(book);

            return response;
        }

        public async Task<IReadOnlyList<BookResponseDto>> GetBooksAsync()
        {
            var books = await _bookRepository.GetItems();

            var response = _mapper.Map<IReadOnlyList<BookResponseDto>>(books);

            return response;
        }

        public async Task<BookResponseDto> UpdateAsync(UpdateBookRequest request, string email)
        {
            // TODO VALIDATOR
            var user = await _userManager.FindByEmailAsync(email);

            var book = _mapper.Map<Book>(request);

            var author = await _authorRepository.GetItem(request.AuthorId);
            var publisher = await _publisherRepository.GetItem(request.PublisherId);

            book.Updated = DateTime.Now;
            book.UpdatedBy = user;
            book.Author = author;
            book.Publisher = publisher;

            book = await _bookRepository.Update(book);

            var response = _mapper.Map<BookResponseDto>(book);

            return response;
        }

        public async Task<List<BookResponseDto>> GetBooksByName(string email)
        {
            var books = await _bookRepository.FindBooksByName(email);

            var response = _mapper.Map<List<BookResponseDto>>(books);

            return response;
        }
    }
}
