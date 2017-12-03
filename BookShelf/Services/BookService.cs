using BookShelf.Infrastructure.Factories;
using BookShelf.Infrastructure.Repositories;
using BookShelf.Models;
using BookShelf.Models.BookViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShelf.Services
{
    public interface IBookService
    {
        IEnumerable<BookViewModel> Get(string userId);
        int AddBook(IBookCreateModel model, string userId);
        void UpdateLoanStatus(int id, bool onLoan, string userId);
        void Delete(int id, string userId);
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

        public IEnumerable<BookViewModel> Get(string userId)
        {
            return _bookRepo.Get()
                .AsQueryable()
                .Where(x => x.UserId == userId)
                .Select(x => BookViewModelFactory.CreateBookViewModel(x));
        }

        public int AddBook(IBookCreateModel model, string userId)
        {
            var author = _authorRepo.Get(model.AuthorId);

            if (author.UserId != userId)
                throw new Exception("Author could not be found.");

            var book = BookFactory.CreateBook(model.Title, author, userId);
            _bookRepo.Add(book);
            _bookRepo.SaveChanges();

            return book.Id;
        }

        public void UpdateLoanStatus(int id, bool onLoan, string userId)
        {
            var book = _bookRepo.Get(id);

            if (book.UserId != userId)
                throw new Exception("Book could not be found.");

            book.OnLoan = onLoan;
            _bookRepo.SaveChanges();
        }

        public void Delete(int id, string userId)
        {
            var book = _bookRepo.Get(id);

            if (book.UserId != userId)
                throw new Exception("Book could not be found.");

            _bookRepo.Delete(book);
            _bookRepo.SaveChanges();
        }
    }
}
