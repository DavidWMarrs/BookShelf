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
        IEnumerable<AuthorViewModel> Get();
        int AddAuthor(IAuthorCreateModel model);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepo;

        public AuthorService(IRepository<Author> authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public IEnumerable<AuthorViewModel> Get()
        {
            return _authorRepo.Get()
                .AsQueryable()
                .Select(x => AuthorViewModelFactory.CreateAuthorViewModel(x));
        }

        public int AddAuthor(IAuthorCreateModel model)
        {
            var author = AuthorFactory.CreateAuthor(model.Name);
            _authorRepo.Add(author);
            _authorRepo.SaveChanges();

            return author.Id;
        }
    }
}
