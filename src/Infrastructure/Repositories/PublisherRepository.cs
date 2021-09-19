using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly LibrosContext _context;

        public PublisherRepository(LibrosContext context)
        {
            _context = context;
        }

        public async Task<Publisher> Create(Publisher request)
        {
            var checkPublisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Name.ToUpper() == request.Name.ToUpper());

            if (checkPublisher != null)
                throw new ItemExistsException($"Publisher with name: { checkPublisher.Name } exists in Database");

            var response = await _context.Publishers.AddAsync(request);

            await _context.SaveChangesAsync();

            return response.Entity;
        }

        public async Task Delete(int id)
        {
            var publisher = await _context.Publishers
                .Include(p => p.Books)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(publisher == null)
                throw new NotFoundException($"Not Found Author with Id {id}");
            if (publisher.Books.Count > 0)
                throw new ItemExistsException("The publisher has books assigned to him. If you want remove publisher, remove the books from him");

            _context.Remove(publisher);

            await _context.SaveChangesAsync();
        }

        public async Task<Publisher> GetItem(int id)
        {
            var publisher = await CheckInDatabase(id);

            return publisher;
        }

        public async Task<IReadOnlyList<Publisher>> GetItems()
        {
            var publishers = await _context.Publishers.ToListAsync();

            return publishers;
        }

        public async Task<Publisher> Update(Publisher request)
        {
            var checkName = await _context.Publishers.Where(p => p.Name == request.Name).ToListAsync();
            if (checkName.Count == 1 && checkName[0].Id != request.Id)
                throw new ItemExistsException($"Publisher with name {request.Name} exists in database");

            var publisherFromDb = await CheckInDatabase(request.Id);

            publisherFromDb.Name = request.Name;
            publisherFromDb.Website = request.Website;
            publisherFromDb.Updated = request.Updated;
            publisherFromDb.UpdatedBy = request.UpdatedBy;

            await _context.SaveChangesAsync();

            return publisherFromDb;

        }

        private async Task<Publisher> CheckInDatabase(int id)
        {
            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(a => a.Id == id);

            if (publisher == null)
                throw new NotFoundException($"Not Found Publisher with Id {id}");

            return publisher;
        }
    }
}
