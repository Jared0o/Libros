using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly LibrosContext _context;

        public BorrowRepository(LibrosContext context)
        {
            _context = context;
        }

        public async Task<BorrowList> Create(BorrowList request)
        {
            var response = await _context.BorrowList
                .AddAsync(request);

            await _context.SaveChangesAsync();

            return response.Entity;
        }

        public async Task ReturnBorrow(int id, User updateBy)
        {
            var borrowList = await  CheckInDatabase(id);

            if (borrowList.IsReturned)
                throw new IsReturnedException($"Book with Id : {id} was returned earlier");

            borrowList.IsReturned = true;
            borrowList.ReturnDate = DateTime.Now;
            borrowList.Updated = DateTime.Now;
            borrowList.UpdatedBy = updateBy;

            await _context.SaveChangesAsync();
        }

        public async Task<BorrowList> GetItem(int id)
        {
            var borrowList = await CheckInDatabase(id);

            return borrowList;
        }

        public async Task<IReadOnlyList<BorrowList>> GetItems()
        {
            var borrowList = await _context.BorrowList
                .Include(b => b.Book).ThenInclude(b => b.Author)
                .Include(b => b.Book).ThenInclude(b => b.Publisher)
                .Include(b => b.User)
                .ToListAsync();

            return borrowList;
        }

        private async Task<BorrowList> CheckInDatabase(int id)
        {
            var borrowList = await _context.BorrowList
                .Include(b => b.Book).ThenInclude(b => b.Author)
                .Include(b => b.Book).ThenInclude(b => b.Publisher)
                .Include(b => b.User)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (borrowList == null)
                throw new NotFoundException($"Not Found Borrow with Id {id}");

            return borrowList;
        }

        public async Task<int> GetActiveBorrowCount()
        {
            var borrowCounter = await _context.BorrowList
                .CountAsync(x => x.IsReturned == false);

            return borrowCounter;
        }

        public async Task<int> GetBorrowCount()
        {
            var borrowCounter = await _context.BorrowList
                .CountAsync();

            return borrowCounter;
        }
    }
}
