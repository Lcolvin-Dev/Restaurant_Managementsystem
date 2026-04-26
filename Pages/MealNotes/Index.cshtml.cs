using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Pages.MealNotes
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantApp.Data.RestaurantContext _context;

        public IndexModel(RestaurantApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Note = await _context.Notes.ToListAsync();
        }
    }
}
