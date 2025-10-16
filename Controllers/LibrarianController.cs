using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using midterm_project.Models;
using System.Linq;
using System.Threading.Tasks;

public class LibrarianController : Controller
{
    private readonly LibraryContext _context;

    public LibrarianController(LibraryContext context)
    {
        _context = context;
    }

    // GET: Librarian
    public async Task<IActionResult> Index()
    {
        var librarians = _context.Librarians.Include(l => l.LibraryBranch);
        return View(await librarians.ToListAsync());
    }

    // GET: Librarian/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var librarian = await _context.Librarians
            .Include(l => l.LibraryBranch)
            .FirstOrDefaultAsync(m => m.LibrarianId == id);

        if (librarian == null) return NotFound();

        return View(librarian);
    }

    // GET: Librarian/Create
    public IActionResult Create()
    {
        ViewData["LibraryBranchId"] = new SelectList(_context.LibraryBranches, "LibraryBranchId", "Name");
        return View();
    }

    // POST: Librarian/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FullName,Email,Phone,HiredDate,LibraryBranchId")] Librarian librarian)
    {
        if (ModelState.IsValid)
        {
            _context.Add(librarian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["LibraryBranchId"] = new SelectList(_context.LibraryBranches, "LibraryBranchId", "Name", librarian.LibraryBranchId);
        return View(librarian);
    }

    // GET: Librarian/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var librarian = await _context.Librarians.FindAsync(id);
        if (librarian == null) return NotFound();

        ViewData["LibraryBranchId"] = new SelectList(_context.LibraryBranches, "LibraryBranchId", "Name", librarian.LibraryBranchId);
        return View(librarian);
    }

    // POST: Librarian/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("LibrarianId,FullName,Email,Phone,HiredDate,LibraryBranchId")] Librarian librarian)
    {
        if (id != librarian.LibrarianId) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(librarian);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Librarians.Any(e => e.LibrarianId == id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }

        ViewData["LibraryBranchId"] = new SelectList(_context.LibraryBranches, "LibraryBranchId", "Name", librarian.LibraryBranchId);
        return View(librarian);
    }

    // GET: Librarian/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var librarian = await _context.Librarians
            .Include(l => l.LibraryBranch)
            .FirstOrDefaultAsync(m => m.LibrarianId == id);

        if (librarian == null) return NotFound();

        return View(librarian);
    }

    // POST: Librarian/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var librarian = await _context.Librarians.FindAsync(id);
        _context.Librarians.Remove(librarian);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
