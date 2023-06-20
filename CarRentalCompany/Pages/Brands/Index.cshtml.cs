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

namespace CarRentalCompany.Pages.Brands
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IGenericRepository<Brand> _repository;

        public IndexModel(IGenericRepository<Brand> repository)
        {
            this._repository = repository;
        }

        public IList<Brand> Brands { get;set; }

        public async Task OnGetAsync()
        {
            Brands = await _repository.GetAll();
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
