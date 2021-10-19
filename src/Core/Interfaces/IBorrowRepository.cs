using Core.Entities;
using Core.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBorrowRepository
    {
        public Task<IReadOnlyList<BorrowList>> GetItems();
        public Task<BorrowList> GetItem(int id);
        public Task<BorrowList> Create(BorrowList request);
        public Task ReturnBorrow(int id, User updateBy);
        public Task<int> GetActiveBorrowCount();
        public Task<int> GetBorrowCount();
    }
}
