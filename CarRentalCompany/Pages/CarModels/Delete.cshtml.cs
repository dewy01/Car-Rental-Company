using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalCompany.Pages.CarModels
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ICarModelsRepository _repository;

        public DeleteModel(ICarModelsRepository repository)
        {
            this._repository = repository;
        }

        public CarModel CarModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel = await _repository.GetCarModelWithDetails(id.Value);

            if (CarModel == null)
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

            CarModel = await _repository.Get(id.Value);

            await _repository.Delete(CarModel.Id);

            return RedirectToPage("./Index");
        }
    }
}