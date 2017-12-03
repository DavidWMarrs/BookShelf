using System;
using Microsoft.AspNetCore.Mvc;
using BookShelf.Services;
using BookShelf.Models.AuthorViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShelf.API
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // POST api/authors
        [HttpPost]
        public int Post(AuthorCreateModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception("Form is invalid.");

            return _authorService.AddAuthor(model);
        }
    }
}
