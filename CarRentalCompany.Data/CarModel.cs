using System.ComponentModel.DataAnnotations;

namespace CarRentalCompany.Data
{
    public class CarModel : BaseDomainEntity
    {
        [Display(Name = "Model")]
        public string Name { get; set; }
        [Display(Name = "Brand")]
        public int? BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
        public List<Car>? Cars { get; set; }
    }
}