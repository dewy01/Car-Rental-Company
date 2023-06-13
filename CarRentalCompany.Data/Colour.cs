using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CarRentalCompany.Data
{
    public class Colour : BaseDomainEntity
    {
        [Display(Name = "Colour")]
        public string Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}