using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCompany.Repositories.Interfaces
{
    public interface ICarsRepository : IGenericRepository<Car>
    {
        Task<Car> GetCarWithDetails(int id);
        Task<List<Car>> GetCarsWithDetails();
    }
}
