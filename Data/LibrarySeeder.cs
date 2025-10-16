using System;
using System.Collections.Generic;
using System.Linq;
using midterm_project.Models;

public static class LibrarySeeder
{
    public static void Seed(LibraryContext context)
    {
        context.Database.EnsureCreated();

        // Prevent reseeding
        if (context.Authors.Any() || context.Books.Any() || context.Customers.Any())
            return;

        // -----------------------------
        // 1️⃣ Authors (20 real)
        // -----------------------------
        var authors = new List<Author>
        {
            new Author { Name = "George Orwell", Bio = "English novelist known for 1984 and Animal Farm." },
            new Author { Name = "Jane Austen", Bio = "Famous for Pride and Prejudice and Sense and Sensibility." },
            new Author { Name = "J.K. Rowling", Bio = "Author of the Harry Potter series." },
            new Author { Name = "J.R.R. Tolkien", Bio = "Author of The Lord of the Rings and The Hobbit." },
            new Author { Name = "Harper Lee", Bio = "Wrote To Kill a Mockingbird." },
            new Author { Name = "F. Scott Fitzgerald", Bio = "Known for The Great Gatsby." },
            new Author { Name = "Ernest Hemingway", Bio = "Wrote The Old Man and the Sea." },
            new Author { Name = "Agatha Christie", Bio = "Mystery novelist behind Hercule Poirot." },
            new Author { Name = "Mark Twain", Bio = "Known for Adventures of Huckleberry Finn." },
            new Author { Name = "Mary Shelley", Bio = "Author of Frankenstein." },
            new Author { Name = "Leo Tolstoy", Bio = "Russian author of War and Peace." },
            new Author { Name = "Charles Dickens", Bio = "Wrote Great Expectations and Oliver Twist." },
            new Author { Name = "Herman Melville", Bio = "Author of Moby-Dick." },
            new Author { Name = "Gabriel García Márquez", Bio = "Wrote One Hundred Years of Solitude." },
            new Author { Name = "Virginia Woolf", Bio = "Modernist writer, Mrs Dalloway." },
            new Author { Name = "Khaled Hosseini", Bio = "Author of The Kite Runner." },
            new Author { Name = "Isabel Allende", Bio = "Wrote The House of the Spirits." },
            new Author { Name = "Toni Morrison", Bio = "Nobel laureate, author of Beloved." },
            new Author { Name = "George R.R. Martin", Bio = "Created A Song of Ice and Fire series." },
            new Author { Name = "Dan Brown", Bio = "Author of The Da Vinci Code." }
        };
        context.Authors.AddRange(authors);
        context.SaveChanges();

        // -----------------------------
        // 2️⃣ Categories
        // -----------------------------
        var categories = new List<Category>
        {
            new Category { Name = "Fantasy", Description = "Magic, adventure, mythical creatures." },
            new Category { Name = "Dystopian", Description = "Oppressive, futuristic societies." },
            new Category { Name = "Romance", Description = "Love and relationships." },
            new Category { Name = "Mystery", Description = "Whodunit and detective stories." },
            new Category { Name = "Historical Fiction", Description = "Stories set in the past." },
            new Category { Name = "Science Fiction", Description = "Futuristic and tech-based stories." },
            new Category { Name = "Adventure", Description = "Exploration and daring experiences." },
            new Category { Name = "Magic Realism", Description = "Blends magical and real elements." },
            new Category { Name = "Tragedy", Description = "Dramatic and sorrowful stories." },
            new Category { Name = "Classic", Description = "Timeless literary works." }
        };
        context.Categories.AddRange(categories);
        context.SaveChanges();

        // -----------------------------
        // 3️⃣ Library Branches
        // -----------------------------
        var branches = new List<LibraryBranch>
        {
            new LibraryBranch { Name = "Central Library", Address = "123 Main St" },
            new LibraryBranch { Name = "North Branch", Address = "89 North Rd" },
            new LibraryBranch { Name = "South Branch", Address = "54 South St" },
            new LibraryBranch { Name = "East Branch", Address = "42 East Ave" },
            new LibraryBranch { Name = "West Branch", Address = "67 West Blvd" }
        };
        context.LibraryBranches.AddRange(branches);
        context.SaveChanges();

        // -----------------------------
        // 4️⃣ Librarians
        // -----------------------------
        var librarians = new List<Librarian>
        {
            new Librarian { FullName="Alice Martin", Email="alice.martin@library.com", Phone="604-555-1001", LibraryBranchId=branches[0].LibraryBranchId },
            new Librarian { FullName="Brian Clark", Email="brian.clark@library.com", Phone="604-555-1002", LibraryBranchId=branches[1].LibraryBranchId },
            new Librarian { FullName="Catherine Lewis", Email="catherine.lewis@library.com", Phone="604-555-1003", LibraryBranchId=branches[2].LibraryBranchId },
            new Librarian { FullName="David Allen", Email="david.allen@library.com", Phone="604-555-1004", LibraryBranchId=branches[3].LibraryBranchId },
            new Librarian { FullName="Emily Scott", Email="emily.scott@library.com", Phone="604-555-1005", LibraryBranchId=branches[4].LibraryBranchId },
            new Librarian { FullName="Frank Harris", Email="frank.harris@library.com", Phone="604-555-1006", LibraryBranchId=branches[0].LibraryBranchId },
            new Librarian { FullName="Grace Lewis", Email="grace.lewis@library.com", Phone="604-555-1007", LibraryBranchId=branches[1].LibraryBranchId },
            new Librarian { FullName="Henry Moore", Email="henry.moore@library.com", Phone="604-555-1008", LibraryBranchId=branches[2].LibraryBranchId },
            new Librarian { FullName="Isabella White", Email="isabella.white@library.com", Phone="604-555-1009", LibraryBranchId=branches[3].LibraryBranchId },
            new Librarian { FullName="Jack Walker", Email="jack.walker@library.com", Phone="604-555-1010", LibraryBranchId=branches[4].LibraryBranchId }
        };
        context.Librarians.AddRange(librarians);
        context.SaveChanges();

        // -----------------------------
        // 5️⃣ Customers
        // -----------------------------
        var customers = new List<Customer>
        {
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

        // -----------------------------
        // 6️⃣ Books
        // -----------------------------
        var books = new List<Book>
        {
            new Book { Title="1984", AuthorId=authors[0].AuthorId, ISBN="9780451524935", PublishedYear=1949, Genre="Dystopian" },
            new Book { Title="Animal Farm", AuthorId=authors[0].AuthorId, ISBN="9780451526342", PublishedYear=1945, Genre="Political Satire" },
            new Book { Title="Pride and Prejudice", AuthorId=authors[1].AuthorId, ISBN="9780141439518", PublishedYear=1813, Genre="Romance" },
            new Book { Title="Harry Potter and the Sorcerer's Stone", AuthorId=authors[2].AuthorId, ISBN="9780590353427", PublishedYear=1997, Genre="Fantasy" },
            new Book { Title="The Hobbit", AuthorId=authors[3].AuthorId, ISBN="9780547928227", PublishedYear=1937, Genre="Fantasy" },
            new Book { Title="To Kill a Mockingbird", AuthorId=authors[4].AuthorId, ISBN="9780061120084", PublishedYear=1960, Genre="Fiction" },
            new Book { Title="The Great Gatsby", AuthorId=authors[5].AuthorId, ISBN="9780743273565", PublishedYear=1925, Genre="Tragedy" },
            new Book { Title="The Old Man and the Sea", AuthorId=authors[6].AuthorId, ISBN="9780684801223", PublishedYear=1952, Genre="Fiction" },
            new Book { Title="Murder on the Orient Express", AuthorId=authors[7].AuthorId, ISBN="9780062693662", PublishedYear=1934, Genre="Mystery" },
            new Book { Title="Adventures of Huckleberry Finn", AuthorId=authors[8].AuthorId, ISBN="9780142437179", PublishedYear=1884, Genre="Adventure" },
            new Book { Title="Frankenstein", AuthorId=authors[9].AuthorId, ISBN="9780141439471", PublishedYear=1818, Genre="Gothic" },
            new Book { Title="War and Peace", AuthorId=authors[10].AuthorId, ISBN="9780199232765", PublishedYear=1869, Genre="Historical" },
            new Book { Title="Great Expectations", AuthorId=authors[11].AuthorId, ISBN="9780141439563", PublishedYear=1861, Genre="Classic" },
            new Book { Title="Moby-Dick", AuthorId=authors[12].AuthorId, ISBN="9780142437247", PublishedYear=1851, Genre="Adventure" },
            new Book { Title="One Hundred Years of Solitude", AuthorId=authors[13].AuthorId, ISBN="9780060883287", PublishedYear=1967, Genre="Magic Realism" },
                        new Book { Title="Mrs Dalloway", AuthorId=authors[14].AuthorId, ISBN="9780156628709", PublishedYear=1925, Genre="Modernist" },
            new Book { Title="The Kite Runner", AuthorId=authors[15].AuthorId, ISBN="9781594631931", PublishedYear=2003, Genre="Drama" },
            new Book { Title="The House of the Spirits", AuthorId=authors[16].AuthorId, ISBN="9780553383805", PublishedYear=1982, Genre="Magic Realism" },
            new Book { Title="Beloved", AuthorId=authors[17].AuthorId, ISBN="9781400033416", PublishedYear=1987, Genre="Historical Fiction" },
            new Book { Title="A Game of Thrones", AuthorId=authors[18].AuthorId, ISBN="9780553593716", PublishedYear=1996, Genre="Fantasy" },
            new Book { Title="The Da Vinci Code", AuthorId=authors[19].AuthorId, ISBN="9780385504201", PublishedYear=2003, Genre="Thriller" }
        };
        context.Books.AddRange(books);
        context.SaveChanges();

        // -----------------------------
        // 7️⃣ Borrow Records (realistic)
        // -----------------------------
        var borrowRecords = new List<BorrowRecord>
        {
            new BorrowRecord { BookId=books[0].BookId, CustomerId=customers[0].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-30), ReturnDate=DateTime.UtcNow.AddDays(-10) },
            new BorrowRecord { BookId=books[1].BookId, CustomerId=customers[1].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-25), ReturnDate=null },
            new BorrowRecord { BookId=books[2].BookId, CustomerId=customers[2].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-60), ReturnDate=DateTime.UtcNow.AddDays(-30) },
            new BorrowRecord { BookId=books[3].BookId, CustomerId=customers[3].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-10), ReturnDate=null },
            new BorrowRecord { BookId=books[4].BookId, CustomerId=customers[4].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-15), ReturnDate=DateTime.UtcNow.AddDays(-5) },
            new BorrowRecord { BookId=books[5].BookId, CustomerId=customers[5].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-20), ReturnDate=null },
            new BorrowRecord { BookId=books[6].BookId, CustomerId=customers[6].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-5), ReturnDate=null },
            new BorrowRecord { BookId=books[7].BookId, CustomerId=customers[7].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-40), ReturnDate=DateTime.UtcNow.AddDays(-10) },
            new BorrowRecord { BookId=books[8].BookId, CustomerId=customers[8].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-50), ReturnDate=DateTime.UtcNow.AddDays(-20) },
            new BorrowRecord { BookId=books[9].BookId, CustomerId=customers[9].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-35), ReturnDate=DateTime.UtcNow.AddDays(-15) },
            new BorrowRecord { BookId=books[10].BookId, CustomerId=customers[10].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-12), ReturnDate=null },
            new BorrowRecord { BookId=books[11].BookId, CustomerId=customers[11].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-22), ReturnDate=null },
            new BorrowRecord { BookId=books[12].BookId, CustomerId=customers[12].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-18), ReturnDate=DateTime.UtcNow.AddDays(-3) },
            new BorrowRecord { BookId=books[13].BookId, CustomerId=customers[13].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-8), ReturnDate=null },
            new BorrowRecord { BookId=books[14].BookId, CustomerId=customers[14].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-28), ReturnDate=DateTime.UtcNow.AddDays(-5) },
            new BorrowRecord { BookId=books[15].BookId, CustomerId=customers[15].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-14), ReturnDate=null },
            new BorrowRecord { BookId=books[16].BookId, CustomerId=customers[16].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-16), ReturnDate=DateTime.UtcNow.AddDays(-2) },
            new BorrowRecord { BookId=books[17].BookId, CustomerId=customers[17].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-21), ReturnDate=null },
            new BorrowRecord { BookId=books[18].BookId, CustomerId=customers[18].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-7), ReturnDate=null },
            new BorrowRecord { BookId=books[19].BookId, CustomerId=customers[19].CustomerId, BorrowDate=DateTime.UtcNow.AddDays(-33), ReturnDate=DateTime.UtcNow.AddDays(-10) }
        };
        context.BorrowRecords.AddRange(borrowRecords);
        context.SaveChanges();

        // -----------------------------
        // 8️⃣ Reviews (realistic)
        // -----------------------------
        var reviews = new List<Review>
        {
            new Review { BookId=books[0].BookId, CustomerId=customers[0].CustomerId, Rating=5, Comment="A thought-provoking dystopian classic.", ReviewDate=DateTime.UtcNow.AddDays(-5) },
            new Review { BookId=books[1].BookId, CustomerId=customers[1].CustomerId, Rating=4, Comment="Short but impactful.", ReviewDate=DateTime.UtcNow.AddDays(-10) },
            new Review { BookId=books[2].BookId, CustomerId=customers[2].CustomerId, Rating=5, Comment="A timeless romance.", ReviewDate=DateTime.UtcNow.AddDays(-15) },
            new Review { BookId=books[3].BookId, CustomerId=customers[3].CustomerId, Rating=5, Comment="Magical and captivating.", ReviewDate=DateTime.UtcNow.AddDays(-20) },
            new Review { BookId=books[4].BookId, CustomerId=customers[4].CustomerId, Rating=4, Comment="Wonderful fantasy adventure.", ReviewDate=DateTime.UtcNow.AddDays(-25) },
            new Review { BookId=books[5].BookId, CustomerId=customers[5].CustomerId, Rating=5, Comment="A powerful story about justice.", ReviewDate=DateTime.UtcNow.AddDays(-30) },
            new Review { BookId=books[6].BookId, CustomerId=customers[6].CustomerId, Rating=4, Comment="Beautifully written.", ReviewDate=DateTime.UtcNow.AddDays(-35) },
            new Review { BookId=books[7].BookId, CustomerId=customers[7].CustomerId, Rating=3, Comment="Good read, but a bit slow.", ReviewDate=DateTime.UtcNow.AddDays(-40) },
            new Review { BookId=books[8].BookId, CustomerId=customers[8].CustomerId, Rating=5, Comment="Mystery kept me hooked!", ReviewDate=DateTime.UtcNow.AddDays(-45) },
            new Review { BookId=books[9].BookId, CustomerId=customers[9].CustomerId, Rating=4, Comment="Classic American literature.", ReviewDate=DateTime.UtcNow.AddDays(-50) },
            new Review { BookId=books[10].BookId, CustomerId=customers[10].CustomerId, Rating=5, Comment="A haunting story.", ReviewDate=DateTime.UtcNow.AddDays(-55) },
            new Review { BookId=books[11].BookId, CustomerId=customers[11].CustomerId, Rating=4, Comment="Very well crafted.", ReviewDate=DateTime.UtcNow.AddDays(-60) },
            new Review { BookId=books[12].BookId, CustomerId=customers[12].CustomerId, Rating=3, Comment="Enjoyable read.", ReviewDate=DateTime.UtcNow.AddDays(-65) },
            new Review { BookId=books[13].BookId, CustomerId=customers[13].CustomerId, Rating=5, Comment="Masterpiece of magic realism.", ReviewDate=DateTime.UtcNow.AddDays(-70) },
            new Review { BookId=books[14].BookId, CustomerId=customers[14].CustomerId, Rating=4, Comment="Very insightful.", ReviewDate=DateTime.UtcNow.AddDays(-75) },
            new Review { BookId=books[15].BookId, CustomerId=customers[15].CustomerId, Rating=5, Comment="Beautiful narrative.", ReviewDate=DateTime.UtcNow.AddDays(-80) },
            new Review { BookId=books[16].BookId, CustomerId=customers[16].CustomerId, Rating=4, Comment="Highly recommended.", ReviewDate=DateTime.UtcNow.AddDays(-85) },
            new Review { BookId=books[17].BookId, CustomerId=customers[17].CustomerId, Rating=5, Comment="Emotional and powerful.", ReviewDate=DateTime.UtcNow.AddDays(-90) },
            new Review { BookId=books[18].BookId, CustomerId=customers[18].CustomerId, Rating=4, Comment="Epic story.", ReviewDate=DateTime.UtcNow.AddDays(-95) },
            new Review { BookId=books[19].BookId, CustomerId=customers[19].CustomerId, Rating=5, Comment="Thrilling and exciting.", ReviewDate=DateTime.UtcNow.AddDays(-100) }
        };
        context.Reviews.AddRange(reviews);
        context.SaveChanges();

        Console.WriteLine("✅ Database seeded successfully with realistic data!");
    }
}

