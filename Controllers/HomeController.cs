using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using midterm_project.Models;

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
}
