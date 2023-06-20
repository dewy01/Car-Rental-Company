using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCompany.Pages.Colours
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IGenericRepository<Colour> _repository;

        public DeleteModel(IGenericRepository<Colour> repository)
        {
            this._repository = repository;
        }

        [BindProperty]
        public Colour Colour { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colour = await _repository.Get(id.Value);

            if (Colour == null)
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

            Colour = await _repository.Get(id.Value);

            await _repository.Delete(Colour.Id);

            return RedirectToPage("./Index");
        }
    }
}