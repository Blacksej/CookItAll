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
    public class IngredientAmountsController : Controller
    {
        private readonly CookItAllContext _context;

        public IngredientAmountsController(CookItAllContext context)
        {
            _context = context;
        }

        // GET: IngredientAmounts
        public async Task<IActionResult> Index()
        {
              return _context.IngredientAmount != null ? 
                          View(await _context.IngredientAmount.ToListAsync()) :
                          Problem("Entity set 'CookItAllContext.IngredientAmount'  is null.");
        }

        // GET: IngredientAmounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IngredientAmount == null)
            {
                return NotFound();
            }

            var ingredientAmount = await _context.IngredientAmount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredientAmount == null)
            {
                return NotFound();
            }

            return View(ingredientAmount);
        }

        // GET: IngredientAmounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IngredientAmounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Unit")] IngredientAmount ingredientAmount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredientAmount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredientAmount);
        }

        // GET: IngredientAmounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IngredientAmount == null)
            {
                return NotFound();
            }

            var ingredientAmount = await _context.IngredientAmount.FindAsync(id);
            if (ingredientAmount == null)
            {
                return NotFound();
            }
            return View(ingredientAmount);
        }

        // POST: IngredientAmounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Unit")] IngredientAmount ingredientAmount)
        {
            if (id != ingredientAmount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredientAmount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientAmountExists(ingredientAmount.Id))
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
            return View(ingredientAmount);
        }

        // GET: IngredientAmounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IngredientAmount == null)
            {
                return NotFound();
            }

            var ingredientAmount = await _context.IngredientAmount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredientAmount == null)
            {
                return NotFound();
            }

            return View(ingredientAmount);
        }

        // POST: IngredientAmounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IngredientAmount == null)
            {
                return Problem("Entity set 'CookItAllContext.IngredientAmount'  is null.");
            }
            var ingredientAmount = await _context.IngredientAmount.FindAsync(id);
            if (ingredientAmount != null)
            {
                _context.IngredientAmount.Remove(ingredientAmount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientAmountExists(int id)
        {
          return (_context.IngredientAmount?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
