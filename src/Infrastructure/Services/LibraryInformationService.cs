using Core.Dtos.Information;
using Core.Interfaces;
using Core.Interfaces.Services;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class LibraryInformationService : ILibraryInformation
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowRepository _borrowRepository;

        public  LibraryInformationService(IBookRepository bookRepository, IBorrowRepository borrowRepository)
        {
            _bookRepository = bookRepository;
            _borrowRepository = borrowRepository;
        }
        public async Task<HomePageInformation> GetHomePageInformation()
        {
            var books = await _bookRepository.GetItems();
            var activeBorrows = await _borrowRepository.GetActiveBorrowCount();
            var borrows = await _borrowRepository.GetBorrowCount();

            return new HomePageInformation { BookCounter = books.Count, ActiveBorrows= activeBorrows, BorrowsNumber = borrows };
        }
    }
}
