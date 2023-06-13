using CarRentalCompany.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCompany.Data
{
    public class CarRentalCompanyDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarRentalCompanyDbContext(DbContextOptions<CarRentalCompanyDbContext> options) : base(options)
        {
               
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Colour> Colours { get; set; }
    }
}
