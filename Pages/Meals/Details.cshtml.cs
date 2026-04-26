using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Pages.Meals
{
    public class DetailsModel : PageModel
    {
        private readonly RestaurantApp.Data.RestaurantContext _context;

        public DetailsModel(RestaurantApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public Meal Meal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meal = await _context.Meals
                .Include(m => m.Category)
                .Include(m => m.Note)
                .FirstOrDefaultAsync(m => m.MealID == id);

            if (Meal == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
