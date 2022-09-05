using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CookItAll.Data;
using CookItAll.Models;

namespace CookItAll.Controllers
{
    public class FridgesController : Controller
    {
        private readonly CookItAllContext _context;

        public FridgesController(CookItAllContext context)
        {
            _context = context;
        }

        // GET: Fridges
        public async Task<IActionResult> Index()
        {
              return _context.Fridge != null ? 
                          View(await _context.Fridge.ToListAsync()) :
                          Problem("Entity set 'CookItAllContext.Fridge'  is null.");
        }

        // GET: Fridges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fridge == null)
            {
                return NotFound();
            }

            var fridge = await _context.Fridge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fridge == null)
            {
                return NotFound();
            }

            return View(fridge);
        }

        // GET: Fridges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fridges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Fridge fridge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fridge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fridge);
        }

        // GET: Fridges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fridge == null)
            {
                return NotFound();
            }

            var fridge = await _context.Fridge.FindAsync(id);
            if (fridge == null)
            {
                return NotFound();
            }
            return View(fridge);
        }

        // POST: Fridges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Fridge fridge)
        {
            if (id != fridge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fridge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FridgeExists(fridge.Id))
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
            return View(fridge);
        }

        // GET: Fridges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fridge == null)
            {
                return NotFound();
            }

            var fridge = await _context.Fridge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fridge == null)
            {
                return NotFound();
            }

            return View(fridge);
        }

        // POST: Fridges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fridge == null)
            {
                return Problem("Entity set 'CookItAllContext.Fridge'  is null.");
            }
            var fridge = await _context.Fridge.FindAsync(id);
            if (fridge != null)
            {
                _context.Fridge.Remove(fridge);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FridgeExists(int id)
        {
          return (_context.Fridge?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
