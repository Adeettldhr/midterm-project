using midterm_project.Models;
 public static class LibrarySeeder
 {
public static void Seed(LibraryContext context)
{
    context.Database.EnsureCreated();

    if (context.Authors.Any()) return;

    // Authors
    var authors = new List<Author>{};
    context.Authors.AddRange(authors);
    context.SaveChanges();

    // Books
    var books = new List<Book> {  };
    context.Books.AddRange(books);
    context.SaveChanges();

    // Customers
    var customers = new List<Customer> { };
    context.Customers.AddRange(customers);
    context.SaveChanges();

    // LibraryBranches
    var branches = new List<LibraryBranch> {  };
    context.LibraryBranches.AddRange(branches);
    context.SaveChanges();

    // Categories, 
            var categories = new List<Category> {  };
    context.Categories.AddRange(categories);
    context.SaveChanges();
    
    //BorrowRecords, 
            var borrowRecords = new List<BorrowRecord> { };
    context.BorrowRecords.AddRange(borrowRecords);
    context.SaveChanges();

    //Reviews, 
            var reviews = new List<Review> {};
    context.Reviews.AddRange(reviews);
    context.SaveChanges();

    //Librarians 
        var librarians = new List<Librarian> {};
    context.Librarians.AddRange(librarians);
    context.SaveChanges();
}
 }