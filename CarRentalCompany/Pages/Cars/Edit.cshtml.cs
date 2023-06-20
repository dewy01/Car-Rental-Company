using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalCompany.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalCompany.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalCompany.Pages.Cars
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ICarsRepository _carRepository;
        private readonly IGenericRepository<CarModel> _carModelRepository;
        private readonly IGenericRepository<Colour> _colourRepository;
        private readonly IGenericRepository<Brand> _brandsRepository;

        public EditModel(ICarsRepository carRepository,
            IGenericRepository<Brand> brandsRepository,
            IGenericRepository<CarModel> carModelRepository,
            IGenericRepository<Colour> colourRepository
        )
        {
            this._carRepository = carRepository;
            this._carModelRepository = carModelRepository;
            this._colourRepository = colourRepository;
            this._brandsRepository = brandsRepository;
        }

        [BindProperty]
        public Car Car { get; set; }

        public SelectList Brands { get; set; }
        public SelectList Models { get; private set; }
        public SelectList Colours { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Car = await _carRepository.Get(id.Value);

            if (Car == null)
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
                await _carRepository.Update(Car);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CarExistsAsync(Car.Id))
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
            Brands = new SelectList(await _brandsRepository.GetAll(), "Id", "Name");
            Models = new SelectList(await _carModelRepository.GetAll(), "Id", "Name");
            Colours = new SelectList(await _colourRepository.GetAll(), "Id", "Name");
        }

        private async Task<bool> CarExistsAsync(int id)
        {
            return await _carRepository.Exists(id);
        }
    }
}
