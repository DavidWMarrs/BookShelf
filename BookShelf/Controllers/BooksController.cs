using Microsoft.AspNetCore.Mvc;
using BookShelf.Services;
using BookShelf.Models.BookViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BookShelf.Models;

namespace BookShelf.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(IBookService bookService, IAuthorService authorService, UserManager<ApplicationUser> userManager)
        {
            _bookService = bookService;
            _authorService = authorService;
            _userManager = userManager;
        }

        // GET: Books
        public IActionResult Index()
        {
            var books = _bookService.Get(_userManager.GetUserId(User));
            var authors = _authorService.Get(_userManager.GetUserId(User));

            return View(new BookIndexViewModel(books, authors));
        }
    }
}
