using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalCompany.Pages.Brands
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IGenericRepository<Brand> _repository;

        public EditModel(IGenericRepository<Brand> repository)
        {
            this._repository = repository;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _repository.Update(Brand);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await MakeExistsAsync(Brand.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> MakeExistsAsync(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
