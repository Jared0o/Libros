using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string NormalizedName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
