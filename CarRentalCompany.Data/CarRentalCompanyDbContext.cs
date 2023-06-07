using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCompany.Data
{
    public class CarRentalCompanyDbContext : DbContext
    {
        public CarRentalCompanyDbContext(DbContextOptions<CarRentalCompanyDbContext> options) : base(options)
        {
               
        }
        public DbSet<Car> Cars { get; set; }
    }
}
