using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCompany.Data
{
    public class Car_Owner : BaseDomainEntity
    {
        public int? CarId { get; set; }
        public Car? Car { get; set; }

        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
