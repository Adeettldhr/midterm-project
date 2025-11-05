using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using midterm_project.Models;
using midterm_project.Exceptions; 

namespace midterm_project.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;
        public BookController(LibraryContext context) => _context = context;

        // GET: Book
        public async Task<IActionResult> Index()
        {
            try
            {
                var books = await _context.Books.Include(b => b.Author).ToListAsync();

                // (Optional: For viva demonstration, uncomment below to simulate DB error)
                // throw new DatabaseConnectionException("Simulated database connection failure.");

                return View(books);
            }
            catch (DbUpdateException ex)
            {
                // Wrap EF errors in a custom exception for global handler
                throw new DatabaseConnectionException($"Database operation failed: {ex.Message}");
            }
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _context.Books.Include(b => b.Author)
                                           .FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
                throw new BookNotFoundException($"Book with ID {id} was not found in the library.");

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["Authors"] = new SelectList(_context.Authors, "AuthorId", "Name");
            return View();
        }

        //  POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Authors"] = new SelectList(_context.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _context.Books.FindAsync(id);
            if (book == null)
                throw new BookNotFoundException($"Book with ID {id} was not found in the library.");

            ViewData["Authors"] = new SelectList(_context.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.BookId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Books.Any(e => e.BookId == id))
                        throw new BookNotFoundException($"Book with ID {id} was not found during update.");
                    else
                        throw; // Let global handler catch any other exceptions
                }
                catch (DbUpdateException ex)
                {
                    throw new DatabaseConnectionException($"Database update failed: {ex.Message}");
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["Authors"] = new SelectList(_context.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _context.Books.Include(b => b.Author)
                                           .FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
                throw new BookNotFoundException($"Book with ID {id} was not found in the library.");

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                throw new BookNotFoundException($"Book with ID {id} was not found during deletion.");

            try
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseConnectionException($"Error while deleting book: {ex.Message}");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
