using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Pages.Menu
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantApp.Data.RestaurantContext _context;

        public IndexModel(RestaurantApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories
                .Include(c => c.Meals)
                    .ThenInclude(m => m.Note)
                .ToListAsync();
        }
    }
}
