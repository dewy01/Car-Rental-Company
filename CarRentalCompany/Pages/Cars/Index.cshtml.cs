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
    public class IndexModel : PageModel
    {
        private readonly CarRentalCompany.Data.CarRentalCompanyDbContext _context;

        public IndexModel(CarRentalCompany.Data.CarRentalCompanyDbContext context)
        {
            _context = context;
        }

        public IList<Car> Cars { get; set; }


        public async Task OnGetAsync()
        {
            Cars = await _context.Cars.ToListAsync();
        }

    }
}