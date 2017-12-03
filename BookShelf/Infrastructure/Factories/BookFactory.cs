using BookShelf.Models;

namespace BookShelf.Infrastructure.Factories
{
    public class BookFactory
    {
        public static Book CreateBook(string title, Author author, string userId)
        {
            return new Book
            {
                Title = title,
                Author = author,
                UserId = userId
            };
        }
    }
}
