using BookShelf.Infrastructure.Factories;
using BookShelf.Infrastructure.Repositories;
using BookShelf.Models;
using BookShelf.Models.AuthorViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookShelf.Services
{
    public interface IAuthorService
    {
        IEnumerable<AuthorViewModel> Get(string userId);
        int AddAuthor(IAuthorCreateModel model, string userId);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepo;

        public AuthorService(IRepository<Author> authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public IEnumerable<AuthorViewModel> Get(string userId)
        {
            return _authorRepo.Get()
                .AsQueryable()
                .Where (x => x.UserId == userId)
                .Select(x => AuthorViewModelFactory.CreateAuthorViewModel(x));
        }

        public int AddAuthor(IAuthorCreateModel model, string userId)
        {
            var author = AuthorFactory.CreateAuthor(model.Name, userId);
            _authorRepo.Add(author);
            _authorRepo.SaveChanges();

            return author.Id;
        }
    }
}
