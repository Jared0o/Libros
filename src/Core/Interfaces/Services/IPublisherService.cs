using Core.Dtos.Publisher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPublisherService
    {
        public Task<PublisherResponseDto> CreateAsync(CreatePublisherRequest request, string userEmail);
        public Task<IReadOnlyList<PublisherResponseDto>> GetPublishersAsync();
        public Task<PublisherResponseDto> GetPublisherAsync(int id);
        public Task DeleteAsync(int id, string userEmail);
        public Task<PublisherResponseDto> UpdateAsync(UpdatePublisherRequest request, string userEmail);
    }
}
