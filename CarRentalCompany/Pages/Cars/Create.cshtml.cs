using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalCompany.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalCompany.Repositories.Contracts;

namespace CarRentalCompany.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ICarsRepository _carRepository;
        private readonly ICarModelsRepository _carModelRepository;
        private readonly IGenericRepository<Colour> _colourRepository;
        private readonly IGenericRepository<Brand> _brandsRepository;

        public CreateModel(ICarsRepository carRepository,
            IGenericRepository<Brand> brandsRepository,
            ICarModelsRepository carModelRepository,
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
        public SelectList Colours { get; set; }
        public SelectList Models { get; set; }

        public async Task<IActionResult> OnGet()
        {
            await LoadInitialData();
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                await LoadInitialData();
                return Page();
            }

            await _carRepository.Insert(Car);

            return RedirectToPage("./Index");
        }

        public async Task<JsonResult> OnGetCarModels(int brandId)
        {
            return new JsonResult(await _carModelRepository.GetCarModelsByBrand(brandId));
        }

        private async Task LoadInitialData()
        {
            Brands = new SelectList(await _brandsRepository.GetAll(), "Id", "Name");
            Models = new SelectList(await _carModelRepository.GetAll(), "Id", "Name");
            Colours = new SelectList(await _colourRepository.GetAll(), "Id", "Name");
        }
    }
}
