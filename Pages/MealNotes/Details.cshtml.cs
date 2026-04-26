using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Pages.MealNotes
{
    public class DetailsModel : PageModel
    {
        private readonly RestaurantApp.Data.RestaurantContext _context;

        public DetailsModel(RestaurantApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public Note Note { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Notes.FirstOrDefaultAsync(m => m.NoteID == id);

            if (Note == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
