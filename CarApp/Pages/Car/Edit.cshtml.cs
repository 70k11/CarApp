using CarApp.Data;
using CarApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Pages.Car
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly AppDbContext context;

        public EditModel(AppDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Cars Cars { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            var cars = await context.Cars.FirstOrDefaultAsync(e => e.CarId == id);

            if (cars == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Cars = cars;

                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Cars.Update(Cars);

            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}