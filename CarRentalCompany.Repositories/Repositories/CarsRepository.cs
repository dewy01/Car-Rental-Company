using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Contracts;
using CarRentalCompany.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCompany.Repositories.Repositories
{
    public class CarsRepository : GenericRepository<Car>, ICarsRepository
    {
        private readonly CarRentalCompanyDbContext _context;

        public CarsRepository(CarRentalCompanyDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Car>> GetCarsWithDetails()
        {
            return await _context.Cars
                .Include(q => q.Brand)
                .Include(q => q.CarModel)
                .Include(q => q.Colour)
                .ToListAsync();
        }

        public async Task<Car> GetCarWithDetails(int id)
        {
            return await _context.Cars
                .Include(q => q.Brand)
                .Include(q => q.CarModel)
                .Include(q => q.Colour)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

    }
}
