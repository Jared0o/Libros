using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    class BookRepository : IBookRepository
    {
        private readonly LibrosContext _context;

        public BookRepository(LibrosContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book request)
        {
            var response = await _context.Books.AddAsync(request);

            await _context.SaveChangesAsync();

            return response.Entity;
        }

        public async Task Delete(int id)
        {
            var book = await CheckInDatabase(id);

            _context.Remove(book);

            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetItem(int id)
        {
            var book = await CheckInDatabase(id);

            return book;
        }

        public async Task<IReadOnlyList<Book>> GetItems()
        {
            var books = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .ToListAsync();

            return books;
        }

        public async Task<Book> Update(Book request)
        {
            var bookFromDb = await CheckInDatabase(request.Id);

            bookFromDb.Name = request.Name;
            bookFromDb.Isbn = request.Isbn;
            bookFromDb.Pages = request.Pages;
            bookFromDb.Publisher = request.Publisher;
            bookFromDb.Updated = request.Updated;
            bookFromDb.UpdatedBy = request.UpdatedBy;
            bookFromDb.Age = request.Age;
            bookFromDb.Author = request.Author;

            await _context.SaveChangesAsync();

            return bookFromDb;
        }

        private async Task<Book> CheckInDatabase(int id)
        {
            var book = await _context.Books
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (book == null)
                throw new NotFoundException($"Not Found Book with Id {id}");

            return book;
        }
    }
}
