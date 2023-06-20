using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCompany.Repositories.Repositories
{
    public class CarModelsRepository : GenericRepository<CarModel>, ICarModelsRepository
    {
        private readonly CarRentalCompanyDbContext _context;
        public CarModelsRepository(CarRentalCompanyDbContext context) : base(context)
        {
            _context = context;            
        }
        public async Task<List<CarModel>> GetCarModelsByBrand(int brandId)
        {
            var models = await _context.CarModels
                .Where(q => q.BrandId == brandId)
                .ToListAsync();

            return models;
        }

        public Task<CarModel> GetCarModelWithDetails(int id)
        {
            return _context.CarModels.Include(q=>q.Brand).FirstOrDefaultAsync(q=>q.Id==id);
        }
    }
}
