using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalCompany.Pages.Colours
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IGenericRepository<Colour> _repository;
        private readonly CarRentalCompanyDbContext _context;

        public IndexModel(IGenericRepository<Colour> repository, CarRentalCompanyDbContext context)
        {
            this._repository = repository;
            this._context = context;
        }

        public IList<Colour> Colour { get;set; }

        public async Task OnGetAsync()
        {
            //Colour = await _repository.GetAll();
            Colour = await _context.Colours.FromSqlRaw($"SelectAllColours").ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? recordid)
        {
            if (recordid == null)
            {
                return NotFound();
            }

            await _repository.Delete(recordid.Value);

            return RedirectToPage();
        }

    }
}
