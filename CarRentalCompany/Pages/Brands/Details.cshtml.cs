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
    public class DetailsModel : PageModel
    {
        private readonly IGenericRepository<Brand> _repository;

        public DetailsModel(IGenericRepository<Brand> repository)
        {
            this._repository = repository;
        }

        public Brand Brand { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Brand = await _repository.Get(id.Value);

            if (Brand == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
