using System;
using Microsoft.AspNetCore.Mvc;
using BookShelf.Services;
using BookShelf.Models.AuthorViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BookShelf.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShelf.API
{
    [Route("api/[controller]")]
    [Authorize]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorsController(IAuthorService authorService, UserManager<ApplicationUser> userManager)
        {
            _authorService = authorService;
            _userManager = userManager;
        }

        // POST api/authors
        [HttpPost]
        public int Post(AuthorCreateModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception("Form is invalid.");

            return _authorService.AddAuthor(model, _userManager.GetUserId(User));
        }
    }
}
