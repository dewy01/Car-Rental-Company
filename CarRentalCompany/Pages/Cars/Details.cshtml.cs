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

    public class DetailsModel : PageModel
    {

        private readonly CarRentalCompany.Data.CarRentalCompanyDbContext _context;

        public DetailsModel(CarRentalCompany.Data.CarRentalCompanyDbContext context)
        {
            _context = context;
        }
        public Car Car { get; set; }    
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if(Car == null) 
            {
                return NotFound();
            }
            return Page();
        }
    }
}
