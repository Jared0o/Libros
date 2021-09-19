using Core.Dtos.Author;
using Core.Dtos.Publisher;

namespace Core.Dtos.Book
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Pages { get; set; }
        public string Isbn { get; set; }
        public AuthorResponseDto Author { get; set; }
        public PublisherResponseDto Publisher { get; set; }
    }
}

