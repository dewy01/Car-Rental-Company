using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CarRentalCompany.Data
{
    public class Owner : BaseDomainEntity
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Owners")]
        public string Name { get; set; }
        public List<Car_Owner>? Car_Owners { get; set; }
    }
}