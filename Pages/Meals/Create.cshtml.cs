using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp.Models;

namespace RestaurantApp.Pages.Meals
{
    public class CreateModel : PageModel
    {
        private readonly RestaurantApp.Data.RestaurantContext _context;

        public CreateModel(RestaurantApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "ShortDescription");
            ViewData["NoteID"] = new SelectList(_context.Notes, "NoteID", "Description");
            return Page();
        }

        [BindProperty]
        public Meal Meal { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "ShortDescription");
                ViewData["NoteID"] = new SelectList(_context.Notes, "NoteID", "Description");
                return Page();
            }

            _context.Meals.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
