using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Contracts;

namespace CarRentalCompany.Pages
{
    public class RentModel : PageModel
    {
        private readonly ICarsRepository _repository;

        public RentModel(ICarsRepository repository)
        {
            this._repository = repository;

        }

        public IList<Car> Cars { get; set; }

        public async Task OnGetAsync()
        {
            Cars = await _repository.GetCarsWithDetails();
          
        }

        public async Task OnPostAsync(int id)
        {

        }

    }
}