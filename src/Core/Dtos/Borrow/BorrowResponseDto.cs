using Core.Dtos.Book;
using Core.Dtos.User;
using System;

namespace Core.Dtos.Borrow
{
    public class BorrowResponseDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public BookResponseDto Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
