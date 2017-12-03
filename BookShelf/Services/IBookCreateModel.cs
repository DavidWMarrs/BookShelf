namespace BookShelf.Services
{
    public interface IBookCreateModel
    {
        string Title { get; }

        int AuthorId { get; }
    }
}
