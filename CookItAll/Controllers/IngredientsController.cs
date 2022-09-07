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
    public class IngredientsController : Controller
    {
        private readonly CookItAllContext _context;

        public IngredientsController(CookItAllContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            return _context.Ingredient != null ?
                        View(await _context.Ingredient.ToListAsync()) :
                        Problem("Entity set 'CookItAllContext.Ingredient'  is null.");
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ingredient == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.Include("Category")
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredients/Create
        public async Task<IActionResult> Create()
        {
            IngredientViewModel cvm = new IngredientViewModel();
            cvm.Categories = await _context.Category.ToListAsync();
            return View(cvm);
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ingredient,Ingredient.Name,CategoryID")] IngredientViewModel ingredientViewModel)
        {
            ModelState.Remove(nameof(ingredientViewModel.Categories));
            ModelState.Remove("Ingredient.IngredientAmounts");

            if (ModelState.IsValid)
            {
                // Add ID check.
                ingredientViewModel.Ingredient.Category = await _context.Category.FirstOrDefaultAsync(m => m.Id == ingredientViewModel.CategoryID);
                _context.Add(ingredientViewModel.Ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ingredientViewModel.Categories = await _context.Category.ToListAsync();
            return View(ingredientViewModel);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["categories"] =  await _context.Category.ToListAsync();
            if (id == null || _context.Ingredient == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Ingredient ingredient, int categoryID)
        {
            ingredient.Category = await _context.Category.FirstOrDefaultAsync(m => m.Id == categoryID);
            if (id != ingredient.ID)
            {
                return NotFound();
            }
            ModelState.Remove("IngredientAmounts");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.ID))
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
            ViewData["categories"] = await _context.Category.ToListAsync();
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ingredient == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ingredient == null)
            {
                return Problem("Entity set 'CookItAllContext.Ingredient'  is null.");
            }
            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient != null)
            {
                _context.Ingredient.Remove(ingredient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return (_context.Ingredient?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
