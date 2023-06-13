using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCompany.Data
{
    public class Brand : BaseDomainEntity
    {
        [Display(Name="Brand")]
        public string Name { get; set; }
        public virtual List<Car>? Cars { get; set; }
        public virtual List<CarModel>? CarModels { get; set; }

    }
}
