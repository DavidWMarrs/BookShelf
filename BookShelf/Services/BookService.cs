using BookShelf.Infrastructure.Factories;
using BookShelf.Infrastructure.Repositories;
using BookShelf.Models;
using BookShelf.Models.BookViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookShelf.Services
{
    public interface IBookService
    {
        IEnumerable<BookViewModel> Get();
        int AddBook(IBookCreateModel model);
        void UpdateLoanStatus(int id, bool onLoan);
        void Delete(int id);
    }

    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepo;
        private readonly IRepository<Author> _authorRepo;
        
        public BookService(IRepository<Book> bookRepo, IRepository<Author> authorRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
        }

        public IEnumerable<BookViewModel> Get()
        {
            return _bookRepo.Get()
                .AsQueryable()
                .Select(x => BookViewModelFactory.CreateBookViewModel(x));
        }

        public int AddBook(IBookCreateModel model)
        {
            var author = _authorRepo.Get(model.AuthorId);
            var book = BookFactory.CreateBook(model.Title, author);
            _bookRepo.Add(book);
            _bookRepo.SaveChanges();

            return book.Id;
        }

        public void UpdateLoanStatus(int id, bool onLoan)
        {
            var book = _bookRepo.Get(id);
            book.OnLoan = onLoan;
            _bookRepo.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _bookRepo.Get(id);
            _bookRepo.Delete(book);
            _bookRepo.SaveChanges();
        }
    }
}
