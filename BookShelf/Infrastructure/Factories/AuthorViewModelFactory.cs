using BookShelf.Models;
using BookShelf.Models.AuthorViewModels;

namespace BookShelf.Infrastructure.Factories
{
    public class AuthorViewModelFactory
    {
        public static AuthorViewModel CreateAuthorViewModel(Author author)
        {
            return new AuthorViewModel
            {
                Id = author.Id,
                Name = author.Name
            };
        }
    }
}
