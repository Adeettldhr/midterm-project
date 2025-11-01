using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using midterm_project.Models;

public class LibraryContext : IdentityDbContext<IdentityUser>
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    // Optional: parameterless constructor for scaffolder / design-time
    public LibraryContext() { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<LibraryBranch> LibraryBranches { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BorrowRecord> BorrowRecords { get; set; }
    public DbSet<Librarian> Librarians { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
