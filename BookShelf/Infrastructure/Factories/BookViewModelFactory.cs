using BookShelf.Models;
using BookShelf.Models.BookViewModels;

namespace BookShelf.Infrastructure.Factories
{
    public class BookViewModelFactory
    {
        public static BookViewModel CreateBookViewModel(Book book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                OnLoan = book.OnLoan
            };
        }
    }
}
