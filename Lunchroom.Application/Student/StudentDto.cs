using Lunchroom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student
{
    public class StudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ClassroomName? ClassroomName { get; set; }
    }
}
