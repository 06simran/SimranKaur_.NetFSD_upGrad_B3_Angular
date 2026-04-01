using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
        }

        // READ - List all movies
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies.ToListAsync();
            return View(movies);
        }

        // READ - View single movie
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // CREATE - Show form
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - Save to DB
        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid)
                return View(movie);

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // UPDATE - Show form with existing data
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // UPDATE - Save changes to DB
        [HttpPost]
        public async Task<IActionResult> Edit(Movie movie)
        {
            if (!ModelState.IsValid)
                return View(movie);

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // DELETE - Show confirmation
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // DELETE - Remove from DB
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}