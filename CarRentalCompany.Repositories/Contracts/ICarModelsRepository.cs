using CarRentalCompany.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCompany.Repositories.Contracts
{
    public interface ICarModelsRepository : IGenericRepository<CarModel>
    {
        Task<List<CarModel>> GetCarModelsByBrand(int brandId);
        Task<CarModel> GetCarModelWithDetails(int id);
    }
}
