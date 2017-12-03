using System;
using Microsoft.AspNetCore.Mvc;
using BookShelf.Services;
using BookShelf.Models.BookViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BookShelf.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShelf.API
{
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(IBookService bookService, UserManager<ApplicationUser> userManager)
        {
            _bookService = bookService;
            _userManager = userManager;
        }

        // POST api/books
        [HttpPost]
        public int Post(BookCreateModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception("Form is invalid.");

            return _bookService.AddBook(model, _userManager.GetUserId(User));
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public void Put(int id, bool onLoan) => _bookService.UpdateLoanStatus(id, onLoan, _userManager.GetUserId(User));

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public void Delete(int id) => _bookService.Delete(id, _userManager.GetUserId(User));
    }
}
