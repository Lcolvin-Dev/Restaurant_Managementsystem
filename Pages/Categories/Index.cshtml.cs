using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantApp.Data.RestaurantContext _context;

        public IndexModel(RestaurantApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public Category? SelectedCategory { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Category = await _context.Categories
                .OrderBy(c => c.ShortDescription)
                .ToListAsync();

            if (id != null)
            {
                SelectedCategory = await _context.Categories
                    .Include(c => c.Meals)
                        .ThenInclude(m => m.Note)
                    .FirstOrDefaultAsync(c => c.CategoryID == id);
            }
        }
    }
}
