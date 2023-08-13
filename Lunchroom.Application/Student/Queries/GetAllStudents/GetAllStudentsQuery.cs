using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Student.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<IEnumerable<StudentDto>>
    {
        public string EncodedName { get; set; }
        public GetAllStudentsQuery(string encodename)
        {
            EncodedName = encodename;
        }
    }
}
