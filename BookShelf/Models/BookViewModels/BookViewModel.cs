namespace BookShelf.Models.BookViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public bool OnLoan { get; set; }
    }
}
