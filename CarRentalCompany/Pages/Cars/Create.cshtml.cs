using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalCompany.Data;

namespace CarRentalCompany.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CarRentalCompany.Data.CarRentalCompanyDbContext _context;

        public CreateModel(CarRentalCompany.Data.CarRentalCompanyDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Car Car { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
