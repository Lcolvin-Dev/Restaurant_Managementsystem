using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp.Models;

namespace RestaurantApp.Pages.MealNotes
{
    public class CreateModel : PageModel
    {
        private readonly RestaurantApp.Data.RestaurantContext _context;

        public CreateModel(RestaurantApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Note Note { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notes.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
