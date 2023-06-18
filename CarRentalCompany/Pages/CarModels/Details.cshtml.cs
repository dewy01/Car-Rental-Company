﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalCompany.Pages.CarModels
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ICarModelsRepository _repository;

        public DetailsModel(ICarModelsRepository repository)
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
    }
}
