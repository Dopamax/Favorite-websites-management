using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FavoriteWebsitesManagement.Data;
using FavoriteWebsitesManagement.Models;

namespace FavoriteWebsitesManagement.Controllers
{
    public class WebsitesController : Controller
    {
        private readonly DbFavoriteWebsites _context;

        public WebsitesController(DbFavoriteWebsites context)
        {
            _context = context;
        }

        // GET: Websites
        public async Task<IActionResult> Index()
        {
              return View(await _context.Websites.ToListAsync());
        }

        // GET: Websites/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Websites == null)
            {
                return NotFound();
            }

            var website = await _context.Websites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (website == null)
            {
                return NotFound();
            }

            return View(website);
        }

        // GET: Websites/Create
        public  IActionResult Create()
        {
            var listeCategories = _context.Categories.AsEnumerable();
            ViewData["categories"] = listeCategories;
            return View();
        }

        // POST: Websites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,link,categoryId")] Website website)
        {
            if (ModelState.IsValid)
            {
                website.Id = Guid.NewGuid();
                _context.Add(website);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(website);
        }

        // GET: Websites/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Websites == null)
            {
                return NotFound();
            }

            var website = await _context.Websites.FindAsync(id);
            if (website == null)
            {
                return NotFound();
            }
            return View(website);
        }

        // POST: Websites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,name,link,categoryId")] Website website)
        {
            if (id != website.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(website);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebsiteExists(website.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(website);
        }

        // GET: Websites/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Websites == null)
            {
                return NotFound();
            }

            var website = await _context.Websites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (website == null)
            {
                return NotFound();
            }

            return View(website);
        }

        // POST: Websites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Websites == null)
            {
                return Problem("Entity set 'DbFavoriteWebsites.Websites'  is null.");
            }
            var website = await _context.Websites.FindAsync(id);
            if (website != null)
            {
                _context.Websites.Remove(website);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebsiteExists(Guid id)
        {
          return _context.Websites.Any(e => e.Id == id);
        }
    }
}
