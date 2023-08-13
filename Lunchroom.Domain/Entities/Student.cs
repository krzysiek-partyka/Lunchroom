using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasLunch { get; set; }
        public int NumberOfLunches { get; set; } = 0;
        public ClassroomName? ClassroomName { get; set; }
        public int? LunchroomId { get; set; }
        public Lunchroom Lunchroom { get; set; }

    }
}
