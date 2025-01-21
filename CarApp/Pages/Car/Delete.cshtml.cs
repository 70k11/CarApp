using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarApp.Data;
using CarApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CarApp.Pages.Car
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext context;

        public DeleteModel(AppDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id==null)
            {
                return Page();
            }

            var cars = await context.Cars.FindAsync(id);

            if (cars == null)
            {
                return Page();
            }
            else
            {
                Cars = cars;

                context.Cars.Remove(Cars);

                await context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
        }
    }
}