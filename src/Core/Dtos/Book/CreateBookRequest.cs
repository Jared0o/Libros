namespace Core.Dtos.Book
{
    public class CreateBookRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Pages { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}

