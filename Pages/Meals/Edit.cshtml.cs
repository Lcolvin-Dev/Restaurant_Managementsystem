using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Pages.Meals
{
    public class EditModel : PageModel
    {
        private readonly RestaurantApp.Data.RestaurantContext _context;

        public EditModel(RestaurantApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meal Meal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.FirstOrDefaultAsync(m => m.MealID == id);

            if (meal == null)
            {
                return NotFound();
            }

            Meal = meal;
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "ShortDescription", Meal.CategoryID);
            ViewData["NoteID"] = new SelectList(_context.Notes, "NoteID", "Description", Meal.NoteID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "ShortDescription", Meal.CategoryID);
                ViewData["NoteID"] = new SelectList(_context.Notes, "NoteID", "Description", Meal.NoteID);
                return Page();
            }

            _context.Attach(Meal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(Meal.MealID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MealExists(int id)
        {
            return _context.Meals.Any(e => e.MealID == id);
        }
    }
}