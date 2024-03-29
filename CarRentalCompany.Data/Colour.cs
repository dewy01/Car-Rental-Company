﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CarRentalCompany.Data
{
    public class Colour : BaseDomainEntity
    {
        [Required]
        [MaxLength (255)]
        [Display(Name = "Colour")]
        public string Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}