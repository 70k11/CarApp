using CarApp.Data;
using CarApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CarApp.Pages.Car
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext context;

        public IndexModel(AppDbContext context)
        {
            this.context = context;
        }

        public IList<Cars> Cars { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Cars = await context.Cars.ToListAsync();
        }
    }
}
