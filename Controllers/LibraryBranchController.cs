using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using midterm_project.Models;
using System.Linq;
using System.Threading.Tasks;

namespace midterm_project.Controllers
{
    public class LibraryBranchController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryBranchController(LibraryContext context) => _context = context;

        // GET: LibraryBranch
        public async Task<IActionResult> Index()
        {
            return View(await _context.LibraryBranches.ToListAsync());
        }

        // GET: LibraryBranch/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var branch = await _context.LibraryBranches.FindAsync(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // GET: LibraryBranch/Create
        public IActionResult Create() => View();

        // POST: LibraryBranch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibraryBranch branch)
        {
            if (ModelState.IsValid)
            {
                _context.LibraryBranches.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        // GET: LibraryBranch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var branch = await _context.LibraryBranches.FindAsync(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // POST: LibraryBranch/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LibraryBranch branch)
        {
            if (id != branch.LibraryBranchId) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.LibraryBranches.Any(e => e.LibraryBranchId == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        // GET: LibraryBranch/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var branch = await _context.LibraryBranches.FindAsync(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // POST: LibraryBranch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await _context.LibraryBranches.FindAsync(id);
            _context.LibraryBranches.Remove(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
