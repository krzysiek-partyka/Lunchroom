using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Domain.Entities
{
    public class LunchroomContactDetails
    {
        public string City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
    }
}
