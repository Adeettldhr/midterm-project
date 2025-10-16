namespace midterm_project.Models
{
    public class HomeViewModel
    {
        public List<Book>? Books { get; set; }
        public List<Author>? Authors { get; set; }
        public List<Customer>? Customers { get; set; }
        public List<LibraryBranch>? LibraryBranches { get; set; }
        public List<Category>? Categories { get; set; }
        public List<BorrowRecord>? BorrowRecords { get; set; }
        public List<Librarian>? Librarians { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
