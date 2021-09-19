using Core.Dtos.Author;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IAuthorService
    {
        public Task<AuthorResponseDto> CreateAuthorAsync(CreateAuthorRequest request, string userEmail);
        public Task<IReadOnlyList<AuthorResponseDto>> GetAuthorsAsync();
        public Task<AuthorResponseDto> GetAuthorAsync(int id);
        public Task DeleteAuthorAsync(int id, string userEmail);
        public Task<AuthorResponseDto> UpdateAuthorAsync(UpdateAuthorRequest request, string userEmail);
    }
}
