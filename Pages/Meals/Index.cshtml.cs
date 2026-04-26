using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Pages.Meals
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantApp.Data.RestaurantContext _context;

        public IndexModel(RestaurantApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IList<Meal> Meal { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Meal = await _context.Meals
                .Include(m => m.Category)
                .Include(m => m.Note)
                .ToListAsync();
        }
    }
}
