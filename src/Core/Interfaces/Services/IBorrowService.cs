using Core.Dtos.Borrow;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IBorrowService
    {
        public Task<BorrowResponseDto> CreateBorrowAsync(CreateBorrowRequest request, string email);
        public Task<BorrowResponseDto> GetBorrowAsync(int id);
        public Task<IReadOnlyList<BorrowResponseDto>> GetBorrowsAsync();
        public Task SetBorrowToReturnedAsync(int id, string email);
        public Task<IReadOnlyList<BorrowResponseDto>> GetNotReturnedBorrows();
        public Task<IReadOnlyList<BorrowResponseDto>> GetReturnedBorrows();
        public Task<IReadOnlyList<BorrowResponseDto>> GetExpiredBorrows();

    }
}
