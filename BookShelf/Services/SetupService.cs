using BookShelf.Infrastructure.Repositories;
using BookShelf.Models;

namespace BookShelf.Services
{
    public interface ISetupService
    {
        void SetupBooks(string userId);
    }

    public class SetupService : ISetupService
    {
        private readonly IRepository<Book> _bookRepo;
        private readonly IRepository<Author> _authorRepo;

        public SetupService(IRepository<Book> bookRepo, IRepository<Author> authorRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
        }

        public void SetupBooks(string userId)
        {
            var author1 = new Author
            {
                Name = "Andy Weir",
                UserId = userId
            };

            var book1 = new Book
            {
                Title = "The Martian",
                Author = author1,
                UserId = userId
            };

            var author2 = new Author
            {
                Name = "Lee Child",
                UserId = userId
            };

            var book2 = new Book
            {
                Title = "One Shot",
                Author = author2,
                UserId = userId
            };

            var author3 = new Author
            {
                Name = "Philip K. Dick",
                UserId = userId
            };

            var book3 = new Book
            {
                Title = "Do Androids Dream Of Electric Sheep?",
                Author = author3,
                OnLoan = true,
                UserId = userId
            };

            _authorRepo.Add(author1);
            _authorRepo.Add(author2);
            _authorRepo.Add(author3);
            _bookRepo.Add(book1);
            _bookRepo.Add(book2);
            _bookRepo.Add(book3);
            _bookRepo.SaveChanges();
        }
    }
}
