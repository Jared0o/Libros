using AutoMapper;
using Core.Dtos.Borrow;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IBookRepository _bookRepository;

        public BorrowService(IBorrowRepository borrowRepository, IMapper mapper, UserManager<User> userManager, IBookRepository bookRepository)
        {
            _borrowRepository = borrowRepository;
            _mapper = mapper;
            _userManager = userManager;
            _bookRepository = bookRepository;
        }

        public async Task<BorrowResponseDto> CreateBorrowAsync(CreateBorrowRequest request, string email)
        {
            //Validator

            var userCreated = await _userManager.FindByEmailAsync(email);
            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            var book = await _bookRepository.GetItem(request.BookId);

            var borrow = _mapper.Map<BorrowList>(request);

            borrow.CreatedBy = userCreated;
            borrow.Created = DateTime.Now;
            borrow.BorrowDate = DateTime.Now;
            borrow.IsReturned = false;

            
            borrow.UserId = user.Id;
            
            borrow.BookId = book.Id;

            borrow = await _borrowRepository.Create(borrow);

            

            borrow.Book = book;
            borrow.User = user;



            var response = _mapper.Map<BorrowResponseDto>(borrow);

            return response;
        }

        public async Task<BorrowResponseDto> GetBorrowAsync(int id)
        {
            var borrow = await _borrowRepository.GetItem(id);

            var response = _mapper.Map<BorrowResponseDto>(borrow);

            return response;
        }

        public async Task<IReadOnlyList<BorrowResponseDto>> GetBorrowsAsync()
        {
            var borrow = await _borrowRepository.GetItems();

            var response = _mapper.Map<IReadOnlyList<BorrowResponseDto>>(borrow);

            return response;
        }

        public async Task SetBorrowToReturnedAsync(int id, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            await _borrowRepository.ReturnBorrow(id, user);
        }

        public async Task<IReadOnlyList<BorrowResponseDto>> GetNotReturnedBorrows()
        {
            var borrows = await _borrowRepository.GetNotReturnedBorrows();

            var response = _mapper.Map<IReadOnlyList<BorrowResponseDto>>(borrows);

            return response;
        }

        public async Task<IReadOnlyList<BorrowResponseDto>> GetReturnedBorrows()
        {
            var borrows = await _borrowRepository.GetReturnedBorrows();

            var response = _mapper.Map<IReadOnlyList<BorrowResponseDto>>(borrows);

            return response;
        }

        public async Task<IReadOnlyList<BorrowResponseDto>> GetExpiredBorrows()
        {
            var borrows = await _borrowRepository.GetExpiredBorrows();

            var response = _mapper.Map<IReadOnlyList<BorrowResponseDto>>(borrows);

            return response;
        }
    }
}
