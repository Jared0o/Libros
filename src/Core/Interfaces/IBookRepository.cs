﻿using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBookRepository : IBaseInterfaceRepository<Book>
    {
        public Task<IReadOnlyList<Book>> FindBooksByName(string name);
    }
}
