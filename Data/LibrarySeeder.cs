using System;
using System.Collections.Generic;
using System.Linq;

public static class LibrarySeeder
{
    public static void Seed(LibraryContext context)
    {
        context.Database.EnsureCreated();

        if (context.Authors.Any() || context.Books.Any() || context.Customers.Any() || context.LibraryBranches.Any())
            return; // already seeded

        // 20 Authors (real author names)
        var authors = new List<Author> {
            new Author { Name = "George Orwell", Bio = "English novelist and essayist" },
            new Author { Name = "Jane Austen"},
            new Author { Name = "J.K. Rowling"},
            new Author { Name = "J.R.R. Tolkien"},
            new Author { Name = "Harper Lee"},
            new Author { Name = "F. Scott Fitzgerald"},
            new Author { Name = "Ernest Hemingway"},
            new Author { Name = "Agatha Christie"},
            new Author { Name = "Mark Twain"},
            new Author { Name = "Mary Shelley"},
            new Author { Name = "Leo Tolstoy"},
            new Author { Name = "Charles Dickens"},
            new Author { Name = "Herman Melville"},
            new Author { Name = "Gabriel García Márquez"},
            new Author { Name = "Virginia Woolf"},
            new Author { Name = "Khaled Hosseini"},
            new Author { Name = "Isabel Allende"},
            new Author { Name = "Toni Morrison"},
            new Author { Name = "George R.R. Martin"},
            new Author { Name = "Dan Brown"}
        };
        context.Authors.AddRange(authors);
        context.SaveChanges();

        // 5 Library branches (to mix with books later)
        var branches = new List<LibraryBranch> {
            new LibraryBranch { Name = "Central Library", Address = "800 Main St" },
            new LibraryBranch { Name = "West End Branch", Address = "120 West St" },
            new LibraryBranch { Name = "East Side Branch", Address = "45 East Ave" },
            new LibraryBranch { Name = "North Shore Branch", Address = "9 North Rd" },
            new LibraryBranch { Name = "South Hill Branch", Address = "77 South St" }
        };
        context.LibraryBranches.AddRange(branches);
        context.SaveChanges();

        // 20 Books (genuine book titles connected to authors above)
        var books = new List<Book>
        {
            new Book { Title = "1984", AuthorId = authors.Single(a=>a.Name=="George Orwell").AuthorId, ISBN="9780451524935", PublishedYear=1949, Genre="Dystopian" },
            new Book { Title = "Animal Farm", AuthorId = authors.Single(a=>a.Name=="George Orwell").AuthorId, ISBN="9780451526342", PublishedYear=1945, Genre="Political Satire" },
            new Book { Title = "Pride and Prejudice", AuthorId = authors.Single(a=>a.Name=="Jane Austen").AuthorId, ISBN="9780141439518", PublishedYear=1813, Genre="Romance" },
            new Book { Title = "Harry Potter and the Sorcerer's Stone", AuthorId = authors.Single(a=>a.Name=="J.K. Rowling").AuthorId, ISBN="9780590353427", PublishedYear=1997, Genre="Fantasy" },
            new Book { Title = "The Hobbit", AuthorId = authors.Single(a=>a.Name=="J.R.R. Tolkien").AuthorId, ISBN="9780547928227", PublishedYear=1937, Genre="Fantasy" },
            new Book { Title = "To Kill a Mockingbird", AuthorId = authors.Single(a=>a.Name=="Harper Lee").AuthorId, ISBN="9780061120084", PublishedYear=1960, Genre="Fiction" },
            new Book { Title = "The Great Gatsby", AuthorId = authors.Single(a=>a.Name=="F. Scott Fitzgerald").AuthorId, ISBN="9780743273565", PublishedYear=1925, Genre="Tragedy" },
            new Book { Title = "The Old Man and the Sea", AuthorId = authors.Single(a=>a.Name=="Ernest Hemingway").AuthorId, ISBN="9780684801223", PublishedYear=1952, Genre="Fiction" },
            new Book { Title = "Murder on the Orient Express", AuthorId = authors.Single(a=>a.Name=="Agatha Christie").AuthorId, ISBN="9780062693662", PublishedYear=1934, Genre="Mystery" },
            new Book { Title = "Adventures of Huckleberry Finn", AuthorId = authors.Single(a=>a.Name=="Mark Twain").AuthorId, ISBN="9780142437179", PublishedYear=1884, Genre="Adventure" },
            new Book { Title = "Frankenstein", AuthorId = authors.Single(a=>a.Name=="Mary Shelley").AuthorId, ISBN="9780141439471", PublishedYear=1818, Genre="Gothic" },
            new Book { Title = "War and Peace", AuthorId = authors.Single(a=>a.Name=="Leo Tolstoy").AuthorId, ISBN="9780199232765", PublishedYear=1869, Genre="Historical" },
            new Book { Title = "Great Expectations", AuthorId = authors.Single(a=>a.Name=="Charles Dickens").AuthorId, ISBN="9780141439563", PublishedYear=1861, Genre="Classic" },
            new Book { Title = "Moby-Dick", AuthorId = authors.Single(a=>a.Name=="Herman Melville").AuthorId, ISBN="9780142437247", PublishedYear=1851, Genre="Adventure" },
            new Book { Title = "One Hundred Years of Solitude", AuthorId = authors.Single(a=>a.Name=="Gabriel García Márquez").AuthorId, ISBN="9780060883287", PublishedYear=1967, Genre="Magic Realism" },
            new Book { Title = "Mrs Dalloway", AuthorId = authors.Single(a=>a.Name=="Virginia Woolf").AuthorId, ISBN="9780156628709", PublishedYear=1925, Genre="Modernist" },
            new Book { Title = "The Kite Runner", AuthorId = authors.Single(a=>a.Name=="Khaled Hosseini").AuthorId, ISBN="9781594631931", PublishedYear=2003, Genre="Drama" },
            new Book { Title = "The House of the Spirits", AuthorId = authors.Single(a=>a.Name=="Isabel Allende").AuthorId, ISBN="9780553383805", PublishedYear=1982, Genre="Magic Realism" },
            new Book { Title = "Beloved", AuthorId = authors.Single(a=>a.Name=="Toni Morrison").AuthorId, ISBN="9781400033416", PublishedYear=1987, Genre="Historical" },
            new Book { Title = "A Game of Thrones", AuthorId = authors.Single(a=>a.Name=="George R.R. Martin").AuthorId, ISBN="9780553593716", PublishedYear=1996, Genre="Fantasy" }
        };
        context.Books.AddRange(books);
        context.SaveChanges();

        // Create BookCopies (distribute across branches)
        var rnd = new Random();
        var copies = new List<BookCopy>();
        foreach(var b in context.Books.ToList())
        {
            // give each book copies in 1-3 branches
            var branchIds = branches.OrderBy(_=>rnd.Next()).Take(rnd.Next(1,4)).Select(x => x.LibraryBranchId);
            foreach(var id in branchIds)
            {
                copies.Add(new BookCopy { BookId = b.BookId, LibraryBranchId = id, Quantity = rnd.Next(1,6) });
            }
        }
        context.BookCopies.AddRange(copies);
        context.SaveChanges();

        // 20 Customers
        var customers = new List<Customer> {
            new Customer { FullName="Alex Johnson", Email="alex.johnson@example.com", Phone="555-0101", RegisteredOn = DateTime.UtcNow.AddMonths(-14) },
            new Customer { FullName="Priya Sharma", Email="priya.sharma@example.com", Phone="555-0102", RegisteredOn = DateTime.UtcNow.AddYears(-1) },
            new Customer { FullName="Liam Brown", Email="liam.brown@example.com", Phone="555-0103", RegisteredOn = DateTime.UtcNow.AddMonths(-3) },
            new Customer { FullName="Sophia Wilson", Email="sophia.wilson@example.com", Phone="555-0104", RegisteredOn = DateTime.UtcNow.AddMonths(-20) },
            new Customer { FullName="Ethan Lee", Email="ethan.lee@example.com", Phone="555-0105", RegisteredOn = DateTime.UtcNow.AddMonths(-6) },
            new Customer { FullName="Olivia Davis", Email="olivia.davis@example.com", Phone="555-0106", RegisteredOn = DateTime.UtcNow.AddMonths(-10) },
            new Customer { FullName="Noah Martinez", Email="noah.m@example.com", Phone="555-0107", RegisteredOn = DateTime.UtcNow.AddMonths(-2) },
            new Customer { FullName="Mia Garcia", Email="mia.garcia@example.com", Phone="555-0108", RegisteredOn = DateTime.UtcNow.AddYears(-2) },
            new Customer { FullName="Lucas Miller", Email="lucas.m@example.com", Phone="555-0109", RegisteredOn = DateTime.UtcNow.AddMonths(-7) },
            new Customer { FullName="Amelia Clark", Email="amelia.c@example.com", Phone="555-0110", RegisteredOn = DateTime.UtcNow.AddMonths(-4) },
            new Customer { FullName="Benjamin Lewis", Email="ben.lewis@example.com", Phone="555-0111", RegisteredOn = DateTime.UtcNow.AddMonths(-9) },
            new Customer { FullName="Charlotte Walker", Email="charlotte.w@example.com", Phone="555-0112", RegisteredOn = DateTime.UtcNow.AddMonths(-11) },
            new Customer { FullName="William Hall", Email="will.hall@example.com", Phone="555-0113", RegisteredOn = DateTime.UtcNow.AddMonths(-5) },
            new Customer { FullName="Isabella Allen", Email="isabella.allen@example.com", Phone="555-0114", RegisteredOn = DateTime.UtcNow.AddMonths(-8) },
            new Customer { FullName="James Young", Email="james.young@example.com", Phone="555-0115", RegisteredOn = DateTime.UtcNow.AddMonths(-13) },
            new Customer { FullName="Emily Hernandez", Email="emily.h@example.com", Phone="555-0116", RegisteredOn = DateTime.UtcNow.AddMonths(-15) },
            new Customer { FullName="Michael King", Email="michael.king@example.com", Phone="555-0117", RegisteredOn = DateTime.UtcNow.AddMonths(-1) },
            new Customer { FullName="Abigail Wright", Email="abigail.w@example.com", Phone="555-0118", RegisteredOn = DateTime.UtcNow.AddMonths(-16) },
            new Customer { FullName="Daniel Lopez", Email="dan.lopez@example.com", Phone="555-0119", RegisteredOn = DateTime.UtcNow.AddMonths(-18) },
            new Customer { FullName="Harper Hill", Email="harper.hill@example.com", Phone="555-0120", RegisteredOn = DateTime.UtcNow.AddMonths(-21) }
        };
        context.Customers.AddRange(customers);
        context.SaveChanges();
    }
}