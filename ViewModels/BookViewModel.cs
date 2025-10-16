//Book.cs
namespace midterm_project.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string AuthorName { get; set; }
        public required string BranchName { get; set; }
        public required string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public bool IsAvailableForBorrowing { get; set; }
    }
}
