using System.Linq;

namespace Core.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Website { get; set; }

        public IQueryable<Book> Books { get; set; }
    }
}
