using Core.Entities.Identity;
using System;

namespace Core.Entities
{
    public class BorrowList : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
