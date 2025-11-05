using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using midterm_project.Models;
using midterm_project.Exceptions; 

public class HomeController : Controller
{
    private readonly LibraryContext _context;

    public HomeController(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var model = new HomeViewModel
        {
            Books = await _context.Books.Include(b => b.Author).ToListAsync(),
            Authors = await _context.Authors.ToListAsync(),
            Customers = await _context.Customers.ToListAsync(),
            LibraryBranches = await _context.LibraryBranches.ToListAsync(),
            Categories = await _context.Categories.ToListAsync(),
            Librarians = await _context.Librarians.ToListAsync(),
            BorrowRecords = await _context.BorrowRecords.ToListAsync(),
            Reviews = await _context.Reviews.ToListAsync()
        };

        return View(model);
    }

    // ✅ Existing error handler
    [Route("Home/Error")]
    public IActionResult Error(int? statusCode = null)
    {
        if (statusCode == 404)
        {
            ViewData["ErrorTitle"] = "Page Not Found";
            ViewData["ErrorMessage"] = "The page you’re looking for doesn’t exist or may have been moved.";
        }
        else if (statusCode == 403)
        {
            ViewData["ErrorTitle"] = "Access Denied";
            ViewData["ErrorMessage"] = "You don’t have permission to view this page.";
        }
        else
        {
            ViewData["ErrorTitle"] = "An Error Occurred";
            ViewData["ErrorMessage"] = "Something went wrong while processing your request.";
        }

        return View("Error");
    }

    // // New action methods to simulate exceptions for testing
    // public IActionResult TestBookError()
    // {
    //     // Simulate missing book exception
    //     throw new BookNotFoundException("The Great Gatsby");
    // }

    // public IActionResult TestDatabaseError()
    // {
    //     // Simulate database connection failure
    //     throw new DatabaseConnectionException("Simulated database connection failure.");
    // }
}
