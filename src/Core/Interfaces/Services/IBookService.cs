using Core.Dtos.Book;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IBookService
    {
        public Task<BookResponseDto> CreateBookAsync(CreateBookRequest request, string email);
        public Task<IReadOnlyList<BookResponseDto>> GetBooksAsync();
        public Task<BookResponseDto> GetBookAsync(int id);
        public Task DeleteAsync(int id, string email);
        public Task<BookResponseDto> UpdateAsync(UpdateBookRequest request, string email);
        public Task<List<BookResponseDto>> GetBooksByName(string email);
    }
}
