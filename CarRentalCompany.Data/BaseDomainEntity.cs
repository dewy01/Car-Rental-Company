using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCompany.Data
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        [AllowNull]
        public DateTime? DateCreated { get; set; }
    }
}
