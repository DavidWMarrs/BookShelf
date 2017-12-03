using BookShelf.Models.AuthorViewModels;
using System.Collections.Generic;

namespace BookShelf.Models.BookViewModels
{
    public class BookIndexViewModel
    {
        public IEnumerable<BookViewModel> Books { get; private set; }

        public IEnumerable<AuthorViewModel> Authors { get; private set; }

        public BookIndexViewModel(IEnumerable<BookViewModel> books, IEnumerable<AuthorViewModel> authors)
        {
            Books = books;
            Authors = authors;
        }
    }
}
