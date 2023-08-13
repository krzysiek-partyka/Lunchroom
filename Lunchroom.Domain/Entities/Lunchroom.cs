using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Domain.Entities
{
    public class Lunchroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LunchesUpdate { get; set; } 
        public decimal LunchPrice { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
        public int? StudentId { get; set; }
        public List<Student>? Student { get; set; } 
        public LunchroomContactDetails ContactDetails { get; set; }
        public string EncodedName { get; private set; }


        public void EncodeName() => EncodedName = Name.ToLower().Replace(' ','-');
    }

}
