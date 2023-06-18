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
    public class CarRentalCompanyDbContext : DbContext
    {
        public CarRentalCompanyDbContext(DbContextOptions<CarRentalCompanyDbContext> options) : base(options)
        {
               
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car_Owner>()
                .HasOne(b => b.Car)
                .WithMany(ba => ba.Car_Owners)
                .HasForeignKey(c => c.CarId);

            modelBuilder.Entity<Car_Owner>()
                .HasOne(b => b.Owner)
                .WithMany(ba => ba.Car_Owners)
                .HasForeignKey(c => c.OwnerId);
        }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car_Owner> Car_Owners { get; set; }


    }
}
