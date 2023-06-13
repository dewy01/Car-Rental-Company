using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCompany.Data
{
    public class Car : BaseDomainEntity
    {

        [Required]
        [Range(1990,2024)]
        [Display(Name = "Manufacture Year")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int? BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
        [Display(Name = "Colour")]
        public int? ColourId { get; set; }
        public virtual Colour? Colour { get; set; }
        [Display(Name = "Model")]
        public int? CarModelId { get; set; }
        public virtual CarModel? CarModel { get; set; }
    }
}
