using System;
using Microsoft.AspNetCore.Mvc;
using BookShelf.Services;
using BookShelf.Models.BookViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShelf.API
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // POST api/books
        [HttpPost]
        public int Post(BookCreateModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception("Form is invalid.");

            return _bookService.AddBook(model);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public void Put(int id, bool onLoan) => _bookService.UpdateLoanStatus(id, onLoan);

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public void Delete(int id) => _bookService.Delete(id);
    }
}
