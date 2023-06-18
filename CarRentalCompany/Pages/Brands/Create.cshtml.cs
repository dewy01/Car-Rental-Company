using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalCompany.Pages.Brands
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IGenericRepository<Brand> _repository;

        public CreateModel(IGenericRepository<Brand> repository)
        {
            this._repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Brand Brand { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.Insert(Brand);

            return RedirectToPage("./Index");
        }
    }
}
