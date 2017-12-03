using System;

namespace BookShelf.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool OnLoan { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public DateTime Created { get; protected set; }

        public string UserId { get; set; }

        public Book()
        {
            Created = DateTime.Now;
        }
    }
}
