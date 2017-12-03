using Microsoft.AspNetCore.Mvc;
using BookShelf.Services;
using BookShelf.Models.BookViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BookShelf.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        // GET: Books
        public IActionResult Index()
        {
            var books = _bookService.Get();
            var authors = _authorService.Get();

            return View(new BookIndexViewModel(books, authors));
        }
    }
}
