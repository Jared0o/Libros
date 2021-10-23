using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibrosContext _context;

        public AuthorRepository(LibrosContext context)
        {
            _context = context;
        }

        public async Task<Author> Create(Author request)
        {
            var checkAuthor = await _context.Authors.FirstOrDefaultAsync(a=> a.NormalizedName == request.NormalizedName);

            if (checkAuthor != null)
                throw new ItemExistsException($"Author with name : {checkAuthor.NormalizedName} exists in Database");

            var response = await _context.Authors.AddAsync(request);

            await _context.SaveChangesAsync();

            return response.Entity;
        }

        public async Task Delete(int id)
        {          
            var author = await _context.Authors
                .Include(b => b.Books)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
                throw new NotFoundException($"Not Found Author with Id {id}");

            if (author.Books.Count > 0)
                throw new ItemExistsException("The author has books assigned to him. If you want remove author, remove the books from him");

            _context.Remove(author);

            await _context.SaveChangesAsync();
        }

        public async Task<Author> GetItem(int id)
        {
            var author = await CheckInDatabase(id);

            return author;
        }

        public async Task<IReadOnlyList<Author>> GetItems()
        {
            var authors = await _context.Authors.ToListAsync();

            return authors;
        }

        public async Task<Author> Update(Author request)
        {
            var checkName = await _context.Authors.Where(a => a.NormalizedName == request.NormalizedName).ToListAsync();
            if (checkName.Count == 1 && checkName[0].Id != request.Id)
                throw new ItemExistsException($"Author with name {request.NormalizedName} exists in database");

            var authorFromDb = await CheckInDatabase(request.Id);

            authorFromDb.FirstName = request.FirstName;
            authorFromDb.LastName = request.LastName;
            authorFromDb.DateOfBirth = request.DateOfBirth;
            if (request.DateOfDeath != null)
                authorFromDb.DateOfDeath = request.DateOfDeath;
            authorFromDb.Updated = DateTime.Now;
            authorFromDb.UpdatedBy = request.UpdatedBy;
            authorFromDb.NormalizedName = request.NormalizedName;

            await _context.SaveChangesAsync();

            return authorFromDb;

        }

        public async Task<IReadOnlyList<Author>> GetAuthorByName(string name)
        {
            var authors = await _context.Authors
                .Where(x => x.NormalizedName.Contains(name.ToUpper()))
                .ToListAsync();

            if (authors == null)
                throw new NotFoundException($"Not Found Authors");

            return authors;
        }

        private async Task<Author> CheckInDatabase(int id)
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
                throw new NotFoundException($"Not Found Author with Id {id}");

            return author;
        }


    }
}
