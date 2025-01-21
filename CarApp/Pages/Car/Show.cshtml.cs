using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarApp.Data;
using CarApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CarApp.Pages.Car
{
    [Authorize]
    public class ShowModel : PageModel
    {
        private readonly AppDbContext context;

        public ShowModel(AppDbContext context)
        {
            this.context = context;
        }

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
    }
}