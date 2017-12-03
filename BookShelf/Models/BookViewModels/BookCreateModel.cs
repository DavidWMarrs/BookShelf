using BookShelf.Services;
using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models.BookViewModels
{
    public class BookCreateModel : IBookCreateModel
    {
        [Required]
        public string Title { get; set; }

        public int AuthorId { get; set; }
    }
}
