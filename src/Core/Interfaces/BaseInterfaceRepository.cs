using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseInterfaceRepository<T> where T : BaseEntity
    {
        public Task<IReadOnlyList<T>> GetItems();
        public Task<T> GetItem(int id);
        public Task<T> Create(T request);
        public Task<T> Update(T request);
        public Task Delete(int id);
    }
}
