using System;

namespace BookShelf.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public string UserId { get; set; }

        public Author()
        {
            Created = DateTime.Now;
        }
    }
}
