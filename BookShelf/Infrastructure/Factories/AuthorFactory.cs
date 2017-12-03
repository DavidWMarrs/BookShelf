using BookShelf.Models;

namespace BookShelf.Infrastructure.Factories
{
    public class AuthorFactory
    {
        public static Author CreateAuthor(string name, string userId)
        {
            return new Author()
            {
                Name = name,
                UserId = userId
                
            };
        }
    }
}
