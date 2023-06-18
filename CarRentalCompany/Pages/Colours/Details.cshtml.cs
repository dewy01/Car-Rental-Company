using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Contracts;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalCompany.Pages.Colours
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IGenericRepository<Colour> _repository;
        private readonly CarRentalCompanyDbContext _context;

        public DetailsModel(IGenericRepository<Colour> repository, CarRentalCompanyDbContext context)
        {
            this._repository = repository;
            _context = context;

        }

        public List<Colour> Colour { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Colour = await _repository.Get(id.Value);
            Colour = await _context.Colours.FromSqlRaw($"SelectColorById {id}").ToListAsync();


            if (Colour == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
