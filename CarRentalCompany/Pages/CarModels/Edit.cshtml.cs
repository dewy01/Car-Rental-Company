using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCompany.Pages.CarModels
{
    public class EditModel : PageModel
    {
        private readonly IGenericRepository<CarModel> _carModelrepository;
        private readonly IGenericRepository<Brand> _makesRepository;

        public EditModel(IGenericRepository<CarModel> carModelrepository, IGenericRepository<Brand> brandsRepository)
        {
            this._carModelrepository = carModelrepository;
            this._makesRepository = brandsRepository;
        }

        [BindProperty]
        public CarModel CarModel { get; set; }
        public SelectList Brands { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel = await _carModelrepository.Get(id.Value);

            if (CarModel == null)
            {
                return NotFound();
            }

            await LoadInitialData();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialData();
                return Page();
            }

            try
            {
                await _carModelrepository.Update(CarModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CarModelExistsAsync(CarModel.Id))
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

        private async Task LoadInitialData()
        {
            Brands = new SelectList(await _makesRepository.GetAll(), "Id", "Name");
        }

        private async Task<bool> CarModelExistsAsync(int id)
        {
            return await _carModelrepository.Exists(id);
        }
    }
}
