using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalCompany.Pages.Brands
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IGenericRepository<Brand> _repository;

        public DeleteModel(IGenericRepository<Brand> repository)
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
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Brand = await _repository.Get(id.Value);

            await _repository.Delete(Brand.Id);

            return RedirectToPage("./Index");
        }
    }
}