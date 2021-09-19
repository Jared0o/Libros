using System.Collections.Generic;

namespace Core.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Website { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
