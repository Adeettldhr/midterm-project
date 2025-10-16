using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using midterm_project.Models;


public class BorrowRecordController : Controller
{
    private readonly LibraryContext _context;

    public BorrowRecordController(LibraryContext context)
    {
        _context = context;
    }

    // GET: BorrowRecord
    public async Task<IActionResult> Index()
    {
        var records = _context.BorrowRecords
            .Include(r => r.Book)
            .Include(r => r.Customer);
        return View(await records.ToListAsync());
    }

    // GET: BorrowRecord/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var record = await _context.BorrowRecords
            .Include(r => r.Book)
            .Include(r => r.Customer)
            .FirstOrDefaultAsync(m => m.BorrowRecordId == id);

        if (record == null) return NotFound();
        return View(record);
    }

    // GET: BorrowRecord/Create
    public IActionResult Create()
    {
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName");
        return View();
    }

    // POST: BorrowRecord/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BookId,CustomerId,BorrowDate,ReturnDate,IsReturned")] BorrowRecord record)
    {
        if (ModelState.IsValid)
        {
            _context.Add(record);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", record.BookId);
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName", record.CustomerId);
        return View(record);
    }

    // GET: BorrowRecord/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var record = await _context.BorrowRecords.FindAsync(id);
        if (record == null) return NotFound();

        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", record.BookId);
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName", record.CustomerId);
        return View(record);
    }

    // POST: BorrowRecord/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("BorrowRecordId,BookId,CustomerId,BorrowDate,ReturnDate,IsReturned")] BorrowRecord record)
    {
        if (id != record.BorrowRecordId) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(record);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.BorrowRecords.Any(e => e.BorrowRecordId == id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }

        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", record.BookId);
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName", record.CustomerId);
        return View(record);
    }

    // GET: BorrowRecord/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var record = await _context.BorrowRecords
            .Include(r => r.Book)
            .Include(r => r.Customer)
            .FirstOrDefaultAsync(m => m.BorrowRecordId == id);

        if (record == null) return NotFound();
        return View(record);
    }

    // POST: BorrowRecord/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var record = await _context.BorrowRecords.FindAsync(id);
        if (record != null)
        {
            _context.BorrowRecords.Remove(record);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
