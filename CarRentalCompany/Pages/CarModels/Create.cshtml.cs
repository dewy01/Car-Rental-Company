using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalCompany.Data;
using Microsoft.EntityFrameworkCore;
using CarRentalCompany.Repositories.Contracts;

namespace CarRentalCompany.Pages.CarModels
{
    public class CreateModel : PageModel
    {
        private readonly IGenericRepository<CarModel> _carModelrepository;
        private readonly IGenericRepository<Brand> _makesRepository;

        public CreateModel(IGenericRepository<CarModel> carModelrepository, IGenericRepository<Brand> makesRepository )
        {
            this._carModelrepository = carModelrepository;
            this._makesRepository = makesRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            await LoadInitialData();
            return Page();
        }

        [BindProperty]
        public CarModel CarModel { get; set; }
        public SelectList Brands { get; private set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialData();
                return Page();
            }

            await _carModelrepository.Insert(CarModel);

            return RedirectToPage("./Index");
        }

        private async Task LoadInitialData()
        {
            Brands = new SelectList(await _makesRepository.GetAll(), "Id", "Name");
        }
    }
}
