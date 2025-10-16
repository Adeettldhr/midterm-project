using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using midterm_project.Models;

public class ReviewController : Controller
{
    private readonly LibraryContext _context;

    public ReviewController(LibraryContext context)
    {
        _context = context;
    }

    // GET: Review
    public async Task<IActionResult> Index()
    {
        var reviews = _context.Reviews
            .Include(r => r.Book)
            .Include(r => r.Customer);
        return View(await reviews.ToListAsync());
    }

    // GET: Review/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var review = await _context.Reviews
            .Include(r => r.Book)
            .Include(r => r.Customer)
            .FirstOrDefaultAsync(m => m.ReviewId == id);

        if (review == null) return NotFound();

        return View(review);
    }

    // GET: Review/Create
    public IActionResult Create()
    {
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName");
        return View();
    }

    // POST: Review/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BookId,CustomerId,Comment,Rating,ReviewDate")] Review review)
    {
        if (ModelState.IsValid)
        {
            _context.Add(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", review.BookId);
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName", review.CustomerId);
        return View(review);
    }

    // GET: Review/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var review = await _context.Reviews.FindAsync(id);
        if (review == null) return NotFound();

        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", review.BookId);
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName", review.CustomerId);
        return View(review);
    }

    // POST: Review/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ReviewId,BookId,CustomerId,Comment,Rating,ReviewDate")] Review review)
    {
        if (id != review.ReviewId) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(review);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Reviews.Any(e => e.ReviewId == id))
                    return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }

        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", review.BookId);
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName", review.CustomerId);
        return View(review);
    }

    // GET: Review/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var review = await _context.Reviews
            .Include(r => r.Book)
            .Include(r => r.Customer)
            .FirstOrDefaultAsync(m => m.ReviewId == id);

        if (review == null) return NotFound();

        return View(review);
    }

    // POST: Review/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
