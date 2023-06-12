using System.ComponentModel.DataAnnotations;

namespace CarRentalCompany.Data
{
    public class Colour : BaseDomainEntity
    {
        [Display(Name = "Colour")]
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}