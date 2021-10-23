using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthorRepository : IBaseInterfaceRepository<Author>
    {
        public Task<IReadOnlyList<Author>> GetAuthorByName(string name);
    }
}
