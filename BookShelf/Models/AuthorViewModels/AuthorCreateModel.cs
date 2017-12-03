using BookShelf.Services;
using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models.AuthorViewModels
{
    public class AuthorCreateModel : IAuthorCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
