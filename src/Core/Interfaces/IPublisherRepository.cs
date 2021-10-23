using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPublisherRepository : IBaseInterfaceRepository<Publisher>
    {
        public Task<IReadOnlyList<Publisher>> GetPublishersByName(string name);
    }
}
