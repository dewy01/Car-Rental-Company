using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalCompany.Pages.Cars
{
    [Authorize]
    public class DeleteModel : PageModel
    {

        private readonly ICarsRepository _repository;

        public DeleteModel(ICarsRepository repository)
        {
            this._repository = repository;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _repository.GetCarWithDetails(id.Value);

            if (Car == null)
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

            Car = await _repository.Get(id.Value);

            await _repository.Delete(Car.Id);

            return RedirectToPage("./Index");
        }
    }
}